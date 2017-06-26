using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Proxy
{
    public class Server : IDisposable
    {
        private TcpListener listener;
        private Dictionary<string, OriginServerClient> clients = new Dictionary<string, OriginServerClient>();

        public void Dispose()
        {
            listener.Stop();
        }

        public async Task Start(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Server created!!\n");
            Console.WriteLine("Waiting for a connection...\n");
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Connected!!\n");

                await HendleClient(client);
            }
        }

        private async Task HendleClient(TcpClient client)
        {
            try
            {
                using (var clientStream = client.GetStream())
                {
                    int requests = 0;
                    Byte[] bytesReceived = new Byte[4096 * 24767];
                    int bytesRead;
                    while ((bytesRead = await clientStream.ReadAsync(bytesReceived, 0, bytesReceived.Length)) != 0)
                    {
                        int sent = 0;
                        String data = Encoding.UTF8.GetString(bytesReceived, 0, bytesRead);
                        Console.WriteLine("Request Header : {0}", data);
                        Headers headers = new Headers(data);
                        var sendData = headers.GetFullHeader();
                        var host = headers["Host"].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("\r\n", "");
                        OriginServerClient originServerClient = GetClient(host);

                        Console.WriteLine($"Requests nr:{++requests}\t " + $"Host:{host} \t" + $"Request:{data.Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]} \n");

                        await originServerClient.Connect(host);
                        await originServerClient.Send(Encoding.UTF8.GetBytes(sendData));
                        await originServerClient.Receive((buffer, count) =>
                        {
                            Console.WriteLine($"*** Received from origin {count} bytes");

                            sent += count;
                            return clientStream.WriteAsync(buffer, 0, count);
                        });
                        Console.WriteLine($"*** Sent to browser {sent} before completion");
                        ReturnClient(host, originServerClient);
                    }
                    bytesReceived = new Byte[4096 * 24];
                    bytesRead = 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ReturnClient(string host, OriginServerClient originServerClient)
        {
            var key = host.ToLowerInvariant();
            clients[key] = originServerClient;
        }

        private OriginServerClient GetClient(string host)
        {
            var key = host.ToLowerInvariant();
            if (clients.ContainsKey(key))
            {
                Console.WriteLine($"!!!! Re-using a new client to {host}");
                return clients[key];
            }
            Console.WriteLine($"!!! Creating a new client to {host}");

            return new OriginServerClient();
        }
    }
}

//listener = new TcpListener(IPAddress.Any, port);
//listener.Start();
//            Console.WriteLine("Server created!!\n");

//            while (true)
//            {
//                var client = await listener.AcceptTcpClientAsync();
//                Console.WriteLine("Connected!!\n");
//                new Task(async () =>
//                {
//    using (var stream = client.GetStream())
//    {
//        Byte[] bytesReceived = new Byte[4096];
//        int bytesRead;
//        while ((bytesRead = await stream.ReadAsync(bytesReceived, 0, bytesReceived.Length)) != 0)
//        {
//            try
//            {
//                String data = Encoding.UTF8.GetString(bytesReceived, 0, bytesRead);
//                Console.WriteLine("Request Header : {0}", data);
//                var sendData = new Headers(data).GetFullHeader();
//                var host = new Headers(data)["Host"].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("\r\n", "");
//                OriginServerClient originServerClient = new OriginServerClient();

//                Console.WriteLine($"Requests nr:{++requests}\t " + $"Host:{host} \t" + $"Request:{data.Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]} \n");

//                await originServerClient.Connect(host);
//                await originServerClient.Send(Encoding.UTF8.GetBytes(sendData));
//                await originServerClient.Receive((buffer, count) =>
//                                {
//                                    return stream.WriteAsync(buffer, 0, count);
//                                });
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//            }
//        }
//    }
//}).Start();
//            }
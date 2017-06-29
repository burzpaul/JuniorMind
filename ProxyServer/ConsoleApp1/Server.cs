using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Server : IDisposable
    {
        private TcpListener listener;
        private Dictionary<string, OriginServerClient> clients = new Dictionary<string, OriginServerClient>();

        public void Dispose()
        {
            listener.Stop();
            clients.Clear();
        }

        public async Task Start(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start(); Console.WriteLine("Server started!\n");
            Console.WriteLine($"Waiting for a connection on port: {listener.LocalEndpoint} \n");
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Connected !! \n");

                await HandleClient(client);
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            int requests = 0;
            try
            {
                using (var clientStream = client.GetStream())
                {
                    while (client.Connected)
                    {
                        Byte[] bytesReceived = new Byte[4096];
                        int bytesRead;
                        String data = "";
                        while ((bytesRead = await clientStream.ReadAsync(bytesReceived, 0, bytesReceived.Length)) != 0)
                        {
                            data += Encoding.UTF8.GetString(bytesReceived, 0, bytesRead);
                            if (data.IndexOf("\r\n\r\n") != -1)
                            {
                                new Task(async () =>
                                {
                                    var header = new Headers(data);
                                    Console.WriteLine($"Requests nr:{++requests}\t" + $"Host:{header["Host"]}\t" + $"Request:{header["Request"]}");
                                    OriginServerClient originServerClient = new OriginServerClient();

                                    var sent = 0;
                                    await originServerClient.ConnectToOrigin(header["Host"]);
                                    await originServerClient.SendRequest(Encoding.UTF8.GetBytes(header.GetFullHeader()));
                                    await originServerClient.ReceiveContentFromOriginServer((buffer, count) =>
                                    {
                                        Console.WriteLine($"*** Received from origin {count} bytes");

                                        sent += count;
                                        return clientStream.WriteAsync(buffer, 0, count);
                                    });
                                }).Start();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
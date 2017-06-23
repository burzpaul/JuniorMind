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

        public void Dispose()
        {
            listener.Stop();
        }

        public async Task Start(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Server created!!");

            Console.WriteLine("Waiting for a connection...");
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Connected!!");
                new Task(async () =>
                {
                    using (var stream = client.GetStream())
                    {
                        Byte[] bytesReceived = new Byte[1500];
                        int bytesRead;
                        while ((bytesRead = await stream.ReadAsync(bytesReceived, 0, bytesReceived.Length)) != 0)
                        {
                            String data = Encoding.UTF8.GetString(bytesReceived, 0, bytesRead);
                            Console.WriteLine("Received : {0} ", data);
                            var sendData = new Headers(data).GetFullHeader();
                            var host = new Headers(data)["Host"].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("\r\n", "");
                            OriginServerClient originServerClient = new OriginServerClient();

                            await originServerClient.Connect(host);
                            await originServerClient.Send(Encoding.UTF8.GetBytes(sendData));
                            await originServerClient.Receive((buffer, count) =>
                            {
                                return stream.WriteAsync(buffer, 0, count);
                            });
                        }
                    }
                }).Start();
            }
        }
    }
}
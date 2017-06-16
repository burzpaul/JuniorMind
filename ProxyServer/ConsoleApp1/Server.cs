using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    public class Server
    {
        private TcpListener listener;

        public async Task Start()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();

            String data = null;

            while (true)
            {
                Console.Write("Waiting for a connection... ");
                try
                {
                    using (var client = await listener.AcceptTcpClientAsync())
                    {
                        Console.WriteLine("Connected!");
                        Byte[] bytes = new Byte[1500];
                        var stream = client.GetStream();

                        int i;

                        while ((i = await stream.ReadAsync(bytes, 0, bytes.Length)) != 0)
                        {
                            data = Encoding.UTF8.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);
                            data = "GET / HTTP/1.1\r\nHost: motherfuckingwebsite.com\r\n\r\n";
                            var changedData = Encoding.UTF8.GetBytes(data);

                            OriginServerClient originServerClient = new OriginServerClient();
                            await originServerClient.Connect();
                            await originServerClient.Send(changedData);
                            await originServerClient.Receive((buffer, count) =>
                            {
                                var content = Encoding.UTF8.GetString(buffer, 0, count);
                                content = content.Replace("fuck", "****");
                                var changedContent = Encoding.UTF8.GetBytes(content);

                                return stream.WriteAsync(changedContent, 0, changedContent.Length);
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
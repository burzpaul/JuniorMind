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
    public class ProxyServer
    {
        private TcpListener listener;

        public async Task Start()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();

            Byte[] bytes = new Byte[256 * 24];
            String data = null;

            while (true)
            {
                Console.Write("Waiting for a connection... ");
                try
                {
                    using (var client = await listener.AcceptTcpClientAsync())
                    {
                        Console.WriteLine("Connected!");

                        var stream = client.GetStream();

                        int i;

                        while ((i = await stream.ReadAsync(bytes, 0, bytes.Length)) != 0)
                        {
                            data = Encoding.UTF8.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);

                            data = "<html><body><h1>Test</h1></body></html>";
                            byte[] msg = Encoding.UTF8.GetBytes(@"HTTP/1.1 200 OK\r\nContent-Length: "
                                + data.Length +
                                "\r\n\r\n" + data);

                            await stream.WriteAsync(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
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
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ProxyServe1
    {
        private TcpListener listener;

        public void Start()
        {
            Listen();
        }

        private async void Listen()
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
            listener.Start();
            Console.WriteLine("Listener started. \n");

            while (true)
            {
                var tcpClient = await listener.AcceptTcpClientAsync();
                if (tcpClient != null)
                {
                    Console.WriteLine($"Conencted to: {tcpClient.Client.RemoteEndPoint} ");
                    HandleClient(tcpClient).Wait();
                }
            }
        }

        private async Task HandleClient(TcpClient tcpClient)
        {
            tcpClient.ReceiveTimeout = 5000;
            RequestHandler requestHandler = new RequestHandler();
            try
            {
                await requestHandler.HandleClient(tcpClient);
            }
            catch (Exception)
            {
            }
            finally
            {
                try
                {
                    if (tcpClient != null)
                    {
                        tcpClient.LingerState = new LingerOption(true, 0);
                        tcpClient.Dispose();
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
}
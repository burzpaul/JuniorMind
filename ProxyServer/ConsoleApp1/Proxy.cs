using System;
using System.Net;
using System.Net.Sockets;

namespace Proxy
{
    public class Proxy
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
                    Console.WriteLine($"Conencted to: {tcpClient.Client.RemoteEndPoint} \n");
                    new RequestHandler().HandleClient(tcpClient);
                    Console.WriteLine("Connection Ended \n");
                }
            }
        }
    }
}
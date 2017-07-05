using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Proxy
{
    public class ServerListener
    {
        private int listenPort;
        private TcpListener listener;

        public ServerListener(int port)
        {
            listenPort = port;
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), listenPort);
        }

        public void StartServer()
        {
            listener.Start();
        }

        public async Task AcceptConnection()
        {
            using (var newClient = await listener.AcceptTcpClientAsync())
            {
                Console.WriteLine($"Connected!! {newClient.Client.RemoteEndPoint}\n");

                RequestHandler client = new RequestHandler(newClient);
                client.StartHandling().Wait();
            }
        }
    }
}
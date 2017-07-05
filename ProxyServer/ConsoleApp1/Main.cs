using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var proxyServer = new ServerListener(5000);
            proxyServer.StartServer();
            Console.WriteLine("Proxy server started. \n");
            Console.WriteLine("Waiting connections!! \n");
            while (true)
            {
                proxyServer.AcceptConnection().Wait();
                proxyServer.AcceptConnection().Wait();
                proxyServer.AcceptConnection().Wait();
                proxyServer.AcceptConnection().Wait(); proxyServer.AcceptConnection().Wait();

                proxyServer.AcceptConnection().Wait();
            }
        }
    }
}
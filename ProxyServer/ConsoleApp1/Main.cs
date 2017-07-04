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
            while (true)
            {
                Console.WriteLine("Waiting connections!! \n");
                proxyServer.AcceptConnectionAsync().Wait();
            }
        }
    }
}
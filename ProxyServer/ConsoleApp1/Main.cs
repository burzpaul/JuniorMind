using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Proxy Server\n");
            var proxyServer = new ServerListener();
            proxyServer.Start();

            Console.ReadLine();
        }
    }
}
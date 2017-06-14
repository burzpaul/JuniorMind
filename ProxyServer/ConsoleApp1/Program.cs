using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new ProxyServer();
            server.Start().Wait();
        }
    }
}
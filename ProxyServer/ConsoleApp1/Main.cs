using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var proxy = new ProxyServer();

            proxy.Start();

            Console.ReadLine();
        }
    }
}
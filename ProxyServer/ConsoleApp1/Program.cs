using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new Server();
            server.Start().Wait();

            Console.ReadLine();
        }
    }
}
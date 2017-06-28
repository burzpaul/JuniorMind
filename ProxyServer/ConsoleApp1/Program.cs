using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating Server \n");
            var clientServer = new Server();
            clientServer.Start(5000).Wait();
            Console.ReadLine();
        }
    }
}
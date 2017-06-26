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
            Console.WriteLine("Creating Server \n");
            var clientServer = new Server();
            clientServer.Start(5000).Wait();
            Console.ReadLine();
        }
    }
}
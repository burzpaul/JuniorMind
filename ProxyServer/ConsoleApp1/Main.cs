using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var proxy = new Proxy();

            proxy.Start();

            Console.ReadLine();
        }
    }
}
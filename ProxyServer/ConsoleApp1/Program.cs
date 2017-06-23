using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating Server :");
            var clientServer = new Server();
            clientServer.Start(5000).Wait();

            //var a = "GET http://juniormind.com/ HTTP/1.1\r\nHost: juniormind.com\r\nProxy-Connection: keep-alive\r\nCache-Control: max-age=0\r\nUpgrade-Insecure-Requests: 1\r\nUser-Agent: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8\r\nDNT: 1\r\nAccept-Encoding: gzip, deflate, sdch\r\nAccept-Language: en-GB,en-US;q=0.8,en;q=0.6\r\nCookie: MSID=ce9be95e-f8b6-42ad-bd9e-7148ee830ec5\r\n\r\n";
            //var b = a.Replace("http://", "");
            //Console.WriteLine(b);

            //var c = b.Substring(b.IndexOf(" "), b.IndexOf("/") - 3);

            //Console.WriteLine(c);
            //var d = c.Trim();
            //Console.WriteLine(d);

            Console.ReadLine();
        }
    }
}
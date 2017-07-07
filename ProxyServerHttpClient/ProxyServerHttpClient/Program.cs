using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProxyServerHttpClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HttpClient client = new HttpClient();

            new Task(async () =>
            {
                using (var response = await client.GetAsync("http://fonts.googleapis.com/css?family=Philosopher:400,700,400italic,700italic"))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(response.Headers);
                }
            }).Start();

            Console.ReadLine();
        }
    }
}
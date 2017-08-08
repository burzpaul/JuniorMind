using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.UnitTests
{
    internal class ProxyServer : IDisposable
    {
        public int BufferSize { get; set; } = 4096;

        public List<ProxyEndPoint> ProxyEndPoints { get; set; }

        public void Start()
        {
            ProxyEndPoints = new List<ProxyEndPoint>(10);
            foreach (var endPoint in ProxyEndPoints)
            {
                Listen(endPoint);
            }
        }

        private async void Listen(ProxyEndPoint endPoint)
        {
            endPoint.Listener = new TcpListener(endPoint.IpAddress, endPoint.Port);
            endPoint.Listener.Start();
            Console.WriteLine("Proxy started. Awaiting connections.\n");

            endPoint.Port = ((IPEndPoint)endPoint.Listener.LocalEndpoint).Port;

            while (true)
            {
                TcpClient client = await endPoint.Listener.AcceptTcpClientAsync();
                if (client != null)
                {
                    Console.WriteLine($"Connection established on port: {client.Client.LocalEndPoint} \n");
                    Task.Run(async () => this);
                }
            }
        }

        public void Stop(ProxyEndPoint endPoint)
        {
            endPoint.Listener.Stop();
            endPoint.Listener.Server.Dispose();
        }

        public void Dispose()
        {
        }
    }
}
using System.Net;
using System.Net.Sockets;

namespace Proxy.UnitTests
{
    public class ProxyEndPoint
    {
        public TcpListener Listener { get; set; }
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; }

        public ProxyEndPoint(IPAddress ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }
    }
}
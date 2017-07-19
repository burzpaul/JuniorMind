using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Proxy
{
    public class ProxyServer : IDisposable
    {
        private TcpStuff tcpClients;
        private RequestHandler requestHandler;
        private ResponseHandler responsHandler;
        private int ConnectionTimeOutSeconds1 { get; set; }
        private List<EndPoint> ProxyEndPoints { get; set; }

        public ProxyServer()
        {
            ConnectionTimeOut = 30;
            ProxyEndPoints = new List<ProxyEnedPoints>
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
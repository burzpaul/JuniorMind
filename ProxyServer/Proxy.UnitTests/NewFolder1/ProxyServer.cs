using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    internal class ProxyServer : IDisposable
    {
        public int BufferSize { get; set; } = 4096;

        public List<ProxyEndPoint> ProxyEndPoints { get; set; }

        private async void Listen()
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Proxy
{
    public class TcpStuff
    {
        public TcpListener Listener { get => Listener; set => Listener = value; }
        public TcpClient SourceClient { get => SourceClient; set => SourceClient = value; }
        public TcpClient OriginClient { get => OriginClient; set => OriginClient = value; }
        public byte[] Buffer { get => Buffer; set => Buffer = value; }
    }
}
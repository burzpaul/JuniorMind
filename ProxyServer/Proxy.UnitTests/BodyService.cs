using System;

namespace Proxy.UnitTests
{
    public class BodyService
    {
        public byte[] body { get; set; }

        public void OnBodyChunkReceived(object source, ResponseEventsArgs e)
        {
            body = e.Response;
        }
    }
}
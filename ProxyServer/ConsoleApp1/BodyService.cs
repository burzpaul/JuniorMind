using System;

namespace Proxy
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
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ResponseEventsArgs : EventArgs
    {
        public byte[] Response { get; set; }
    }

    public class ResponseHandler
    {
        public EventHandler<ResponseEventsArgs> Something;

        private string header { get; set; }
        private byte[] body { get; set; }
        private bool headerReceived = false;

        public void HandleResponse(byte[] response)
        {
            if (headerReceived == false)
            {
                header += Encoding.UTF8.GetString(response);
                if (header.IndexOf("\r\n\r\n") != -1)
                {
                    var check = header.Replace(header.Substring(0, header.IndexOf("\r\n\r\n") + 8), "");
                    headerReceived = true;
                    body = check.Length > 1 ? body : null;
                    OnHeadersComplete(header.Substring(0, header.IndexOf("\r\n\r\n") + 8));
                }
            }
            else
            {
                if (body != null)
                {
                    var temp = body;
                    body = null;
                    OnBodyChunkReceived(temp);
                }
                else
                {
                    OnBodyChunkReceived(response);
                }
            }
        }

        protected virtual void OnHeadersComplete(string responseMessage)
        {
            Something?.Invoke(this, new ResponseEventsArgs { Response = Encoding.UTF8.GetBytes(responseMessage) });
        }

        protected virtual void OnBodyChunkReceived(byte[] responseMessage)
        {
            Something?.Invoke(this, new ResponseEventsArgs { Response = responseMessage });
        }
    }
}
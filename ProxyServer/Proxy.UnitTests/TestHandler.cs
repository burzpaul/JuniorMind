using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    public class ResponseEventsArgs : EventArgs
    {
        public byte[] Response { get; set; }
    }

    public class ResponseHandler
    {
        public EventHandler<ResponseEventsArgs> HeadersComplete;

        public void HandleResponse(byte[] responseMessage)
        {
            var responseMessageString = Encoding.UTF8.GetString(responseMessage);
            var responseHeader = responseMessageString.Substring(0, responseMessageString.IndexOf("\r\n\r\n"));
            var responseBody = responseMessageString.Substring(responseMessageString.IndexOf("\r\n\r\n"), responseMessageString.Length - responseHeader.Length);

            OnHeadersComplete(responseMessage);
        }

        protected virtual void OnHeadersComplete(byte[] responseMessage)
        {
            HeadersComplete?.Invoke(this, new ResponseEventsArgs { Response = responseMessage });
        }

        protected virtual void OnBodyChunkReceived(byte[] responseMessage)
        {
            HeadersComplete?.Invoke(this, new ResponseEventsArgs { Response = responseMessage });
        }
    }
}
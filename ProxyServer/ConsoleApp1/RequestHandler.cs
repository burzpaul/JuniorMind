using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class RequestHandler
    {
        private NetworkStream clientStream;
        private byte[] buffer = new byte[4096];
        private string host;
        private string requestHeader;

        public async Task HandleClient(TcpClient tcpClient)
        {
            try
            {
                bool complete = false;
                clientStream = tcpClient.GetStream();

                Header header = new Header();

                header.HeaderCompleted += (sender, e) =>
                {
                    host = e.HeaderFields.Get("Host");
                    requestHeader = e.HeaderFields.GetModifiedHeader;
                    complete = e.IsComplete;
                };

                while (!complete)
                {
                    var readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);
                    header.ProcessHeader(buffer, readBytes);
                }

                Console.WriteLine(requestHeader.Split(' ')[0]);

                ResponseHandler responseHandler = new ResponseHandler();

                responseHandler.HandleClient(host, Encoding.UTF8.GetBytes(requestHeader)).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
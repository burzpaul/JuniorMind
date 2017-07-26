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
        private Controller controller = new Controller();
        private byte[] buffer = new byte[4096];
        private string host;
        private string request;
        private byte[] requestHeader;

        public async Task HandleClient(TcpClient tcpClient)
        {
            try
            {
                bool complete = false;

                clientStream = tcpClient.GetStream();

                controller.HeaderCompleted += (sender, e) =>
                {
                    host = e.HeaderFields.Get("Host");
                    request = e.HeaderFields.GetRequest;
                    requestHeader = e.HeaderFields.GetModifiedRequest;
                    complete = e.IsComplete;
                };

                while (!complete)
                {
                    var readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);

                    controller.Feed(buffer, readBytes);
                }

                Console.WriteLine($"Request: {request} \n");

                ResponseHandler responseHandler = new ResponseHandler();

                responseHandler.HandleClient(host, requestHeader).Wait();

                var sentBytes = 0;
                responseHandler.ReceiveResponse((responseBuffer, responseBytesReceived) =>
                {
                    Console.WriteLine($"*** Received from origin {responseBytesReceived} bytes \n");
                    sentBytes += responseBytesReceived;
                    return clientStream.WriteAsync(responseBuffer, 0, responseBytesReceived);
                }).Wait();

                tcpClient.Dispose();
                clientStream.Dispose();
                await clientStream.FlushAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class RequestHandler
    {
        private List<string> requestLines = new List<string>();

        internal async Task HandleClient(TcpClient tcpClient)
        {
            int requestNr = 0;
            var clientStream = tcpClient.GetStream();
            var clientStreamReader = new StreamReader(clientStream);
            Uri remoteUri;

            try
            {
                string data;
                while (!string.IsNullOrEmpty((data = await clientStreamReader.ReadLineAsync())))
                {
                    requestLines.Add(data + "\r\n");
                }
                Console.WriteLine($"Requests nr: {++requestNr}\t" + $"Request: {requestLines[0]}\n");
                remoteUri = new Uri(requestLines[0].Split(' ')[1]);
                requestLines[0] = requestLines[0].Replace("http://", "").Replace(remoteUri.Host, "");
                var requestHeader = Encoding.UTF8.GetBytes(string.Concat(requestLines.ToArray()) + "\r\n");

                ResponseHandler responseHandler = new ResponseHandler();
                var sentBytes = 0;
                await responseHandler.HandleClient(remoteUri.Host, requestHeader);
                await responseHandler.ReceiveResponse((responseBuffer, responseBytesReceived) =>
                {
                    Console.WriteLine($"*** Received from origin {responseBytesReceived} bytes \n");
                    sentBytes += responseBytesReceived;
                    return clientStream.WriteAsync(responseBuffer, 0, responseBytesReceived);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
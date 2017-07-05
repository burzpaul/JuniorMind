using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    public class RequestHandler
    {
        private TcpClient client;

        public RequestHandler(TcpClient newClinet)
        {
            client = newClinet;
        }

        public async Task StartHandling()
        {
            Console.WriteLine("Handling Request");
            await Handler();
        }

        private async Task Handler()
        {
            int requestsNr = 0;
            bool requestReceived = false;
            string request = string.Empty;
            byte[] clientBuffer = new byte[4096];
            string EOL = "\r\n";
            using (var stream = client.GetStream())
            {
                while (!requestReceived)
                {
                    var readBytes = await stream.ReadAsync(clientBuffer, 0, clientBuffer.Length);
                    request += Encoding.UTF8.GetString(clientBuffer, 0, readBytes);
                    if (request.EndsWith(EOL + EOL))
                    {
                        Console.WriteLine(request);
                        requestReceived = true;
                    }
                }

                var requestHeader = new ProcessHeaders(request);
                request = request.Replace("http://" + requestHeader["Host"], "");
                Console.WriteLine($"Requests nr: {++requestsNr}\t" + $"Host: {requestHeader["Host"]}\t" + $"Request: {requestHeader["Absolut Uri"]} \n");

                ResponseHandler responseHandler = new ResponseHandler(requestHeader["Host"], Encoding.UTF8.GetBytes(request));

                var sentBytes = 0;
                await responseHandler.ReceiveResponse((responseBuffer, responseBytesReceived) =>
                {
                    Console.WriteLine($"*** Received from origin {responseBytesReceived} bytes \n");
                    sentBytes += responseBytesReceived;
                    return stream.WriteAsync(responseBuffer, 0, responseBytesReceived);
                });
            }
        }
    }
}
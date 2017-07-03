using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class OriginServerClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private Byte[] buffer;

        public async Task ConnectToOrigin(string host)
        {
            client = new TcpClient();
            await client.ConnectAsync(host.Split(' ')[1].Replace("\r\n", ""), 80);
        }

        public async Task SendRequest(byte[] data)
        {
            stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            await stream.FlushAsync();
        }

        public async Task ReceiveContentFromOriginServer(Func<byte[], int, Task> onData)
        {
            var responseHandler = new ResponseHandler();

            var headerService = new HeaderService();

            var bodyService = new BodyService();

            try
            {
                var totalBytesSent = 0;
                int contentLength;
                buffer = new Byte[4096];
                responseHandler.Something += headerService.OnHeadersCompleted;
                responseHandler.Something += bodyService.OnBodyChunkReceived;
                var a = Int32.TryParse(headerService.header["Content-Length"].Split(' ')[2].Replace("\r\n", ""), out contentLength);
                while (a == false)
                {
                    await stream.ReadAsync(buffer, 0, buffer.Length);
                    responseHandler.HandleResponse(buffer);
                }
                while (totalBytesSent < contentLength)
                {
                    var readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                    await onData(bodyService.body, readBytes);
                    responseHandler.HandleResponse(buffer);
                    totalBytesSent += readBytes;
                }
                await stream.FlushAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
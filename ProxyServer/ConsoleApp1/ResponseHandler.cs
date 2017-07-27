using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Proxy
{
    public class ResponseHandler
    {
        private TcpClient client;
        private ProxyState controller = new ProxyState();
        private NetworkStream clientStream;
        private byte[] buffer = new byte[4096];

        private List<string> responseLines = new List<string>();

        public async Task HandleClient(string host, byte[] request)
        {
            client = new TcpClient();
            await client.ConnectAsync(host, 80);
            clientStream = client.GetStream();
            await clientStream.WriteAsync(request, 0, request.Length);
            await clientStream.FlushAsync();
        }

        public async Task ReceiveResponse(Func<byte[], int, Task> onDataReceived)
        {
            try
            {
                bool contentComplete = false;

                buffer = new byte[4096];

                controller.ChunkCompleted += (sender, e) => contentComplete = e.IsComplete;

                controller.BodyCompleted += (sender, e) => contentComplete = e.IsComplete;

                while (!contentComplete)
                {
                    var readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);

                    controller.Feed(buffer, readBytes);

                    await onDataReceived(buffer, readBytes);
                }

                client.Dispose();
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
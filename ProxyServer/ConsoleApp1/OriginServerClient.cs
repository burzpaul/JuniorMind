using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class OriginServerClient
    {
        private TcpClient client;
        private Byte[] buffer;
        private NetworkStream stream;

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
            try
            {
                var contentLength = 0;
                var totalBytesSent = 0;
                buffer = new Byte[4096];
                var read = 0;
                while (totalBytesSent < contentLength)
                {
                    read = await stream.ReadAsync(buffer, 0, buffer.Length);
                    await onData(buffer, read);
                    totalBytesSent += read;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
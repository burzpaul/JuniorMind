using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Proxy
{
    internal class OriginServerClient
    {
        private TcpClient client;

        public async Task Connect(string host)
        {
            client = new TcpClient();
            await client.ConnectAsync(host, 80);
        }

        public async Task Send(byte[] data)
        {
            var stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            await stream.FlushAsync();
        }

        public async Task Receive(Func<byte[], int, Task> onData)
        {
            try
            {
                Byte[] buffer = new Byte[4096];
                var stream = client.GetStream();
                var read = 0;
                while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await onData(buffer, read);
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
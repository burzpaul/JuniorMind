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
            await Handler();
        }

        private async Task Handler()
        {
            List<string> requestLines = new List<string>();
            bool requestReceived = false;
            string request = string.Empty;
            byte[] buffer = new byte[4096];
            string EOL = "\r\n";
            using (var stream = client.GetStream())
            {
                while (!requestReceived)
                {
                    var readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                    request += Encoding.UTF8.GetString(buffer, 0, readBytes);
                    if (request.EndsWith(EOL + EOL))
                    {
                        Console.WriteLine(request);
                        requestReceived = true;
                    }
                }
                if (client != null)
                {
                    client.LingerState = new LingerOption(true, 0);
                    client.Dispose();
                }
            }
        }
    }
}
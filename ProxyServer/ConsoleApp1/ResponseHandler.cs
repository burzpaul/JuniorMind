using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace Proxy
{
    public class ResponseHandler
    {
        private byte[] request;
        private string host;
        private TcpClient client = new TcpClient();
        private byte[] buffer = new byte[4096];

        public ResponseHandler(string host, byte[] request)
        {
            this.host = host;
            this.request = request;
            StartHandling().Wait();
        }

        private async Task StartHandling()
        {
            await Connect();
            await SendRequest();
        }

        private async Task Connect()
        {
            await client.ConnectAsync(host, 80);
        }

        private async Task SendRequest()
        {
            var stream = client.GetStream();
            stream.Write(request, 0, request.Length);
            await stream.FlushAsync();
        }

        public async Task ReceiveResponse(Func<byte[], int, Task> onDataReceived)
        {
            using (var stream = client.GetStream())
            {
                string EOL = "\r\n";
                var body = string.Empty;
                bool reponseHeaderReceived = false;
                var totalBytesSent = 0;
                var responseData = string.Empty;
                var responseHeader = string.Empty;

                while (!reponseHeaderReceived)
                {
                    var readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                    responseData += Encoding.UTF8.GetString(buffer, 0, readBytes);
                    if (responseData.Contains(EOL + EOL))
                    {
                        responseHeader = responseData.Split(new string[] { EOL + EOL }, 2, StringSplitOptions.None)[0] + EOL + EOL;
                        body = responseData.Replace(responseHeader, "");
                        totalBytesSent = Encoding.UTF8.GetBytes(body).Length;
                        reponseHeaderReceived = true;
                    }
                    await onDataReceived(Encoding.UTF8.GetBytes(responseHeader), Encoding.UTF8.GetByteCount(responseHeader));
                }

                var header = new ProcessHeaders(responseHeader);
                if (header["Transfer-Encoding"] == "chunked")
                {
                }
                else
                {
                    await onDataReceived(Encoding.UTF8.GetBytes(body), Encoding.UTF8.GetByteCount(body));
                    while (totalBytesSent < Int32.Parse(header["Content-Length"]))
                    {
                        var readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                        await onDataReceived(buffer, readBytes);
                        totalBytesSent += readBytes;
                    }
                }
            }
        }
    }
}
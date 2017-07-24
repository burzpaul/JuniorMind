using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ResponseHandler
    {
        private TcpClient client;
        private NetworkStream clientStream;
        private byte[] buffer;

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
                string EOL = "\r\n";
                var body = string.Empty;
                bool reponseHeaderReceived = false;
                var totalBytesSent = 0;
                var responseData = string.Empty;
                var responseHeader = string.Empty;
                buffer = new byte[4096];
                while (!reponseHeaderReceived)
                {
                    var readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);
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
                    var a = Encoding.UTF8.GetBytes(body);
                    bool result = false;
                    Chunk chunk = new Chunk();
                    chunk.ChunkCompleted += (sender, e) => result = e.IsComplete;
                    //buffer = buffer.Concat(a);
                    while (!result)
                    {
                        var readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);
                        chunk.ProcessChunk(buffer);
                        await onDataReceived(buffer, readBytes);
                    }
                }
                else
                {
                    await onDataReceived(Encoding.UTF8.GetBytes(body), Encoding.UTF8.GetByteCount(body));
                    while (totalBytesSent < Int32.Parse(header["Content-Length"]))
                    {
                        var readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);
                        await onDataReceived(buffer, readBytes);
                        totalBytesSent += readBytes;
                    }
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
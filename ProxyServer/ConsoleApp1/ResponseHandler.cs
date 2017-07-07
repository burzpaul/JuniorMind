using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ResponseHandler
    {
        private TcpClient client;
        private NetworkStream clientStream;

        //private StreamReader clientStreamReader;
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

                await onDataReceived(Encoding.UTF8.GetBytes(body), Encoding.UTF8.GetByteCount(body));
                while (totalBytesSent < Int32.Parse(header["Content-Length"]))
                {
                    var readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);
                    await onDataReceived(buffer, readBytes);
                    totalBytesSent += readBytes;
                }
            }
            //try
            //{
            //    string data;
            //    var readBytes = 1;
            //    int contentLength = 0;
            //    int totalBytesSent = 0;
            //    buffer = new byte[4096];
            //    clientStreamReader = new StreamReader(clientStream);
            //    while (!string.IsNullOrEmpty((data = await clientStreamReader.ReadLineAsync())))
            //    {
            //        if (data.Contains("Content-Length:"))
            //        {
            //            contentLength = Int32.Parse(data.Split(' ')[1]);
            //        }
            //        responseLines.Add(data + "\r\n");
            //    }

            //    var responseHeader = Encoding.UTF8.GetBytes(string.Concat(responseLines.ToArray()) + "\r\n");
            //    await onDataReceived(responseHeader, responseHeader.Length);
            //    totalBytesSent += responseHeader.Length;
            //    while (readBytes != 0)
            //    {
            //        readBytes = await clientStream.ReadAsync(buffer, 0, buffer.Length);
            //        Console.WriteLine(Encoding.UTF8.GetString(buffer));
            //        await onDataReceived(buffer, readBytes);
            //        totalBytesSent += readBytes;
            //    }
            //}
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //private async Task Connect()
        //{
        //    await client.ConnectAsync(host, 80);
        //}

        //private async Task SendRequest()
        //{
        //    var stream = client.GetStream();
        //    stream.Write(request, 0, request.Length);
        //    await stream.FlushAsync();
        //}

        //public async Task ReceiveResponse(Func<byte[], int, Task> onDataReceived)
        //{
        //    using (var stream = client.GetStream())
        //    {
        //        string EOL = "\r\n";
        //        var body = string.Empty;
        //        bool reponseHeaderReceived = false;
        //        var totalBytesSent = 0;
        //        var responseData = string.Empty;
        //        var responseHeader = string.Empty;

        //        while (!reponseHeaderReceived)
        //        {
        //            var readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
        //            responseData += Encoding.UTF8.GetString(buffer, 0, readBytes);
        //            if (responseData.Contains(EOL + EOL))
        //            {
        //                responseHeader = responseData.Split(new string[] { EOL + EOL }, 2, StringSplitOptions.None)[0] + EOL + EOL;
        //                body = responseData.Replace(responseHeader, "");
        //                totalBytesSent = Encoding.UTF8.GetBytes(body).Length;
        //                reponseHeaderReceived = true;
        //            }
        //            await onDataReceived(Encoding.UTF8.GetBytes(responseHeader), Encoding.UTF8.GetByteCount(responseHeader));
        //        }

        //        var header = new ProcessHeaders(responseHeader);
        //        if (header["Transfer-Encoding"] == "chunked")
        //        {
        //        }
        //        else
        //        {
        //            await onDataReceived(Encoding.UTF8.GetBytes(body), Encoding.UTF8.GetByteCount(body));
        //            while (totalBytesSent < Int32.Parse(header["Content-Length"]))
        //            {
        //                var readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
        //                await onDataReceived(buffer, readBytes);
        //                totalBytesSent += readBytes;
        //            }
        //        }
        //    }
        //}

        //public async Task<byte[]> Decompress(byte[] compressedArray, int bufferSize)
        //{
        //    using (var decompressor = new GZipStream(new MemoryStream(compressedArray), CompressionMode.Decompress))
        //    {
        //        var buffer = new byte[bufferSize];

        //        using (var output = new MemoryStream())
        //        {
        //            int read;
        //            while ((read = await decompressor.ReadAsync(buffer, 0, buffer.Length)) > 0)
        //            {
        //                output.Write(buffer, 0, read);
        //            }

        //            return output.ToArray();
        //        }
        //    }
        //}
    }
}
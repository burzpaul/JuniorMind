using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class HandleClient
    {
        private TcpClient rqClient;
        private NetworkStream rqClientStream;
        private StreamReader rqClientStreamReader;
        private string host;
        private string request;
        private TcpClient rsClient;

        public HandleClient(TcpClient client)
        {
            this.rqClient = client;
            HandlingClient().Wait();
        }

        private async Task HandlingClient()
        {
            await HandlingRequest();
            Console.WriteLine(host);
        }

        public async Task HandlingRequest()
        {
            using (rqClientStream = rqClient.GetStream())
            using (rqClientStreamReader = new StreamReader(rqClientStream))
            {
                request = string.Empty;
                string temp = string.Empty;

                while (!string.IsNullOrEmpty((temp = await rqClientStreamReader.ReadLineAsync())))
                {
                    request += temp + "\r\n";
                }
                request += "\r\n";
                var requestHeader = new ProcessHeaders(request);

                request.Replace(requestHeader["Absolut Uri"], requestHeader["Host"]);

                host = requestHeader["Host"];
            }
        }
    }
}
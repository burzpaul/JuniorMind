using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class StreamHandler
    {
        private byte[] buffer;
        private byte[] CRLF = new byte[] { 13, 10, 13, 10 };

        public void HandleStream(NetworkStream stream)
        {
        }

        //private async Task ContainsAsync()
        //{
        //    await stream.ReadAsync(buffer, 0, buffer.Length);

        //    int i = 0;

        //    int length = buffer.Length;

        //    while (i < length)
        //    {
        //        switch (buffer[i])
        //        {
        //            case
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
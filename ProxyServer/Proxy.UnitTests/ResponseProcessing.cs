using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    public class ProcessResponse
    {
        public event EventHandler<HeaderCompleteEventArgs> eventHeaderComplete;

        public void Something(byte[] array)
        {
            eventHeaderComplete(this, new HeaderCompleteEventArgs(Encoding.UTF8.GetString(array)));
        }
    }

    public class HeaderCompleteEventArgs : EventArgs
    {
        public HeaderCompleteEventArgs(string array)
        {
            header = new Headers(array.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)[0]);
        }

        public Headers header { get; set; }
    }
}
using System;

namespace Proxy
{
    public class HeaderCompleteEventArgs : EventArgs
    {
        public bool IsComplete { get; set; }
        public HeaderFields HeaderFields { get; set; }
    }
}
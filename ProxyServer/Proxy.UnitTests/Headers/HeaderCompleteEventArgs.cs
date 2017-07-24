using System;

namespace Proxy.UnitTests.Headers
{
    public class HeaderCompleteEventArgs : EventArgs
    {
        public bool IsComplete { get; set; }
        public HeaderFields HeaderFields { get; set; }
    }
}
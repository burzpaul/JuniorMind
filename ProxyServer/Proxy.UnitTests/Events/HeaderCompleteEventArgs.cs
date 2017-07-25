using System;

namespace Proxy.UnitTests
{
    public class HeaderCompleteEventArgs : EventArgs
    {
        public bool IsComplete { get; set; }
        public HeaderFields HeaderFields { get; set; }
    }
}
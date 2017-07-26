using System;

namespace Proxy
{
    public class BodyCompleteEventArgs : EventArgs
    {
        public bool IsComplete { get; set; }
    }
}
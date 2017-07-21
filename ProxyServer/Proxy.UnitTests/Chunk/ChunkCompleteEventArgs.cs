using System;

namespace Proxy.UnitTests
{
    public class ChunkCompleteEventArgs : EventArgs
    {
        public bool IsComplete { get; set; }
        public byte[] Chunk { get; set; }
    }
}
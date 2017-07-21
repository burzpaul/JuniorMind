using System;

namespace Proxy
{
    public class ChunkCompleteEventArgs : EventArgs
    {
        public bool IsComplete { get; set; }
        public byte[] Chunk { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    internal class Chunk
    {
        public event EventHandler<ChunkCompleteEventArgs> ChunkComplete;

        public void Something(string something)
        {
            OnChunkComplete(something);
        }

        protected virtual void OnChunkComplete(string e)
        {
            ChunkComplete?.Invoke(this, new ChunkCompleteEventArgs() { Chunk = "YESSS" });
        }
    }

    public class ChunkCompleteEventArgs : EventArgs
    {
        public string Chunk { get; set; }
    }
}
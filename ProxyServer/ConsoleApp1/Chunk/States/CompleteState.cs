using System;

namespace Proxy
{
    internal class CompleteState : ChunkState
    {
        private Chunk chunk;

        public CompleteState(Chunk chunk)
        {
            this.chunk = chunk;
            this.chunk.OnChunkComplete(true);
        }

        internal override void Handle(byte bite, Action<ChunkState> state)
        {
            chunk.ChangeState(null);
        }
    }
}
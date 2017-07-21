using System;

namespace Proxy
{
    internal class CompleteState : ChunkState
    {
        private Chunk chunk;

        public CompleteState(Chunk chunk)
        {
            this.chunk = chunk;
            this.chunk.OnChunkCompleted(true, new byte[] { });
        }

        internal override void Handle(byte bite, Action<ChunkState> state)
        {
            chunk.ChangeState(null);
        }
    }
}
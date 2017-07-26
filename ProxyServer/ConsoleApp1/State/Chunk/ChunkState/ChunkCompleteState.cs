using System;

namespace Proxy
{
    internal class ChunkCompleteState : State
    {
        private Chunk chunk;

        public ChunkCompleteState(Chunk chunk)
        {
            this.chunk = chunk;
        }

        internal override void Handle(byte bite, Action<State> state)
        {
            chunk.ChangeState(null);
            chunk.OnChunkComplete();
        }
    }
}
using System;

namespace Proxy
{
    internal class NewLineState : ChunkState
    {
        private Chunk chunk;

        public NewLineState(Chunk chunk)
        {
            this.chunk = chunk;
        }

        internal override void Handle(byte data, Action<ChunkState> state)
        {
            if (data == '\n')
            {
                chunk.ChangeState(new ContentState(chunk));
            }
            else
            {
                chunk.OnChunkComplete(false);
                throw new Exception("Protocol violation, Line Feed expected.");
            }
        }
    }
}
using System;

namespace Proxy.UnitTests
{
    internal class NumberOrCrState : ChunkState
    {
        private Chunk chunk;

        public NumberOrCrState(Chunk chunk)
        {
            this.chunk = chunk;
        }

        internal override void Handle(byte data, Action<ChunkState> state)
        {
            if (('0' <= data && data <= '9')
                || ((byte)'A' <= data && (byte)'E' <= data)
                || ((byte)'a' <= data && (byte)'e' <= data))
            {
                chunk.OnLength(data);
            }
            else if (data == '\r')
            {
                chunk.ChangeState(new NewLineState(chunk));
            }
            else
            {
                chunk.OnChunkCompleted(false, new byte[] { });
                throw new Exception("Protocol violation, Carriage Return expected.");
            }
        }
    }
}
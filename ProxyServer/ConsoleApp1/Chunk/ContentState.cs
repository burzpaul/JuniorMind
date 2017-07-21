using System;
using System.Text;

namespace Proxy
{
    internal class ContentState : ChunkState
    {
        private Chunk chunk;
        private int size;

        public ContentState(Chunk chunk)
        {
            this.chunk = chunk;
        }

        internal override void Handle(byte data, Action<ChunkState> state)
        {
            if (chunk.GetExpectedLength == 0)
            {
                chunk.ChangeState(new CompleteState(chunk));
                return;
            }
            else if (chunk.GetExpectedLength > size)
            {
                size++;
                return;
            }
            else if (chunk.GetExpectedLength == size)
            {
                if (data == '\r')
                {
                    return;
                }
                if (data == '\n')
                {
                    chunk.ResetLength();
                    chunk.ChangeState(new NumberOrCrState(chunk));
                }
                else
                {
                    chunk.OnChunkCompleted(false, new byte[] { });
                    //throw new Exception("New line did not respect the protocol. Invalid length, smaller.");
                }
            }
            else
            {
                chunk.OnChunkCompleted(false, new byte[] { });
                throw new Exception("This cannot be. Invalid Chunk length.");
            }
        }
    }
}
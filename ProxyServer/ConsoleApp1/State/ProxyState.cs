using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ProxyState
    {
        private State state;

        private byte[] buffer = new byte[4096];

        public event EventHandler<HeaderCompleteEventArgs> HeaderCompleted;

        public event EventHandler<ChunkCompleteEventArgs> ChunkCompleted;

        public event EventHandler<BodyCompleteEventArgs> BodyCompleted;

        public ProxyState()
        {
            state = new Header(this);
        }

        public void Feed(byte[] data, int length)
        {
            for (int i = 0; i < length; i++)
            {
                state.Handle(data[i], ChangeState);
            }
        }

        public void ChangeState(State state)
        {
            this.state = state;
        }

        public void OnHeaderComplete(bool headerComplete, HeaderFields headerFields)
        {
            HeaderCompleted?.Invoke(this, new HeaderCompleteEventArgs() { IsComplete = headerComplete, HeaderFields = headerFields });
        }

        public void OnChunkComplete()
        {
            ChunkCompleted?.Invoke(this, new ChunkCompleteEventArgs() { IsComplete = true });
        }

        public void OnBodyComplete()
        {
            BodyCompleted?.Invoke(this, new BodyCompleteEventArgs() { IsComplete = true });
        }
    }
}
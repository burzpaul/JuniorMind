using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.UnitTests
{
    public class Controller
    {
        private State state;

        private byte[] buffer = new byte[4096];

        public event EventHandler<HeaderCompleteEventArgs> HeaderCompleted;

        public event EventHandler<ChunkCompleteEventArgs> ChunkCompleted;

        public Controller()
        {
            state = new Header(this);
        }

        public void Feed(byte[] data)
        {
            foreach (var item in data)
            {
                state.Handle(item, ChangeState);
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
    }
}
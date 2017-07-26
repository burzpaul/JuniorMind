using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    internal class Chunk : State
    {
        private string length;
        private State state;
        private Controller controller;

        public Chunk(Controller controller)
        {
            this.controller = controller;
            state = new ChunkNumberOrCrState(this);
        }

        internal override void Handle(byte data, Action<State> state)
        {
            this.state.Handle(data, ChangeState);
        }

        public int GetGetExpectedLength => int.Parse(length, System.Globalization.NumberStyles.HexNumber);

        public void ResetLength()
        {
            length = null;
        }

        public void ChangeState(State state)
        {
            this.state = state;
        }

        public void OnLength(byte data)
        {
            length += (char)data;
        }

        public void OnChunkComplete()
        {
            controller.OnChunkComplete();
        }
    }
}
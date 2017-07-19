using System;

namespace Proxy.UnitTests
{
    internal class CompleteState : IState
    {
        private ChunkBody body;

        public CompleteState(ChunkBody body)
        {
            this.body = body;
            this.body.TriggerComplete();
        }

        public void Feed(byte data, Action<IState> changeState)
        {
            changeState(null);
        }
    }
}
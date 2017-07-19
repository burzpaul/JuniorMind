using System;

namespace Proxy.UnitTests
{
    internal class ContentState : IState
    {
        private ChunkBody body;
        private int size;

        public ContentState(ChunkBody body)
        {
            this.body = body;
        }

        public void Feed(byte data, Action<IState> changeState)
        {
            if (body.ExpectedLength == 0)
            {
                changeState(new CompleteState(body));
                return;
            }
            if (data != '\r' || data != '\n')
            {
                size += 1;
            }
        }
    }
}
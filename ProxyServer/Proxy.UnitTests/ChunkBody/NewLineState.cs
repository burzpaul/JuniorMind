using System;

namespace Proxy.UnitTests
{
    internal class NewLineState : IState
    {
        private ChunkBody body;

        public NewLineState(ChunkBody body)
        {
            this.body = body;
        }

        public void Feed(byte data, Action<IState> changeState)
        {
            if (data == '\n')
            {
                changeState(new ContentState(body));
            }
            else
            {
                throw new Exception("Protocol violation, Line Feed expected");
            }
        }
    }
}
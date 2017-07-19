using System;

namespace Proxy.UnitTests
{
    internal class NumberOrCrState : IState
    {
        private ChunkBody body;

        public NumberOrCrState(ChunkBody body)
        {
            this.body = body;
        }

        public void Feed(byte data, Action<IState> changeState)
        {
            if ('0' <= data && data <= '9')
            {
                body.OnLength(data);
            }
            else if (data == '\r')
            {
                changeState(new NewLineState(body));
            }
            else
            {
                throw new Exception("Protocol violation, Carriage Return expected");
            }
        }
    }
}
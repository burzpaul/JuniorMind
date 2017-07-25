using System;

namespace Proxy.UnitTests
{
    internal class HeaderFieldState : State
    {
        private Header header;

        public HeaderFieldState(Header header)
        {
            this.header = header;
        }

        internal override void Handle(byte data, Action<State> changeState)
        {
            if (data == '\r')
            {
                header.OnHeaderChar(data);
                header.ChangeState(new HeaderNewLineState(header));
                return;
            }
            else if (data == '\n')
            {
                throw new Exception("Protocol violation. Carriage return expected");
            }
            else
            {
                header.OnHeaderChar(data);
                return;
            }
        }
    }
}
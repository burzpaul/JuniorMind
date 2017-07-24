using System;

namespace Proxy.UnitTests.Headers
{
    internal class FieldState : HeaderState
    {
        private Header header;

        public FieldState(Header header)
        {
            this.header = header;
        }

        public override void Handle(byte data, Action<HeaderState> changeState)
        {
            if (data == '\r')
            {
                header.HeaderChar(data);
                header.ChangeState(new NewLineState(header));
                return;
            }
            else if (data == '\n')
            {
                throw new Exception("Protocol violation. Carriage return expected");
            }
            else
            {
                header.HeaderChar(data);
                return;
            }
        }
    }
}
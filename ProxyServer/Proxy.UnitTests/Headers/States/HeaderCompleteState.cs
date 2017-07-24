using System;

namespace Proxy.UnitTests.Headers
{
    internal class HeaderCompleteState : HeaderState
    {
        private Header header;

        public HeaderCompleteState(Header header)
        {
            this.header = header;
        }

        public override void Handle(byte data, Action<HeaderState> changeState)
        {
            if (data == '\n')
            {
                header.HeaderChar(data);
                header.OnHeaderComplete();
                header.ChangeState(null);
            }
            else
            {
                throw new Exception("Protocol violation. Line feed expected");
            }
        }
    }
}
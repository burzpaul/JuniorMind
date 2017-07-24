using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests.Headers
{
    internal class NewLineState : HeaderState
    {
        private Header header;

        public NewLineState(Header header)
        {
            this.header = header;
        }

        public override void Handle(byte data, Action<HeaderState> changeState)
        {
            if (data == '\n')
            {
                header.HeaderChar(data);
                header.ChangeState(new IsCompleteState(header));
                return;
            }
            else
            {
                throw new Exception("Protocol violation. Line feed expected");
            }
        }
    }
}
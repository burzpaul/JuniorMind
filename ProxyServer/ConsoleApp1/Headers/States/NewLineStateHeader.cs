using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class NewLineStateHeader : HeaderState
    {
        private Header header;

        public NewLineStateHeader(Header header)
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
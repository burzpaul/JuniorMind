using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    internal class HeaderNewLineState : State
    {
        private Header header;

        public HeaderNewLineState(Header header)
        {
            this.header = header;
        }

        internal override void Handle(byte data, Action<State> changeState)
        {
            if (data == '\n')
            {
                header.OnHeaderChar(data);
                header.ChangeState(new HeaderIsCompleteState(header));
            }
            else
            {
                throw new Exception("Protocol violation. Line feed expected");
            }
        }
    }
}
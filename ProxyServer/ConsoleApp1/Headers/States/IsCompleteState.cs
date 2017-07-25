using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    internal class IsCompleteState : HeaderState
    {
        private Header header;

        public IsCompleteState(Header header)
        {
            this.header = header;
        }

        public override void Handle(byte data, Action<HeaderState> changeState)
        {
            if (data == '\r')
            {
                header.HeaderChar(data);
                header.ChangeState(new HeaderCompleteState(header));
            }
            else
            {
                if (data == '\n')
                {
                    throw new Exception("Protocol violation. Carriage feed or character expected");
                }
                else
                {
                    header.HeaderChar(data);
                    header.ChangeState(new FieldState(header));
                    return;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    internal class HeaderIsCompleteState : State
    {
        private Header header;

        public HeaderIsCompleteState(Header header)
        {
            this.header = header;
        }

        internal override void Handle(byte data, Action<State> changeState)
        {
            if (data == '\r')
            {
                header.OnHeaderChar(data);
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
                    header.OnHeaderChar(data);
                    header.ChangeState(new HeaderFieldState(header));
                    return;
                }
            }
        }
    }
}
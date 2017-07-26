using System;

namespace Proxy
{
    internal class HeaderCompleteState : State
    {
        private Header header;

        public HeaderCompleteState(Header header)
        {
            this.header = header;
        }

        internal override void Handle(byte data, Action<State> changeState)
        {
            if (data == '\n')
            {
                header.OnHeaderChar(data);
                header.ChangeState(null);
                header.OnHeaderComplete();
            }
            else
            {
                throw new Exception("Protocol violation. Line feed expected");
            }
        }
    }
}
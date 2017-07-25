using System;

namespace Proxy
{
    public abstract class HeaderState
    {
        public abstract void Handle(byte item, Action<HeaderState> changeState);
    }
}
using System;

namespace Proxy.UnitTests.Headers
{
    public abstract class HeaderState
    {
        public abstract void Handle(byte item, Action<HeaderState> changeState);
    }
}
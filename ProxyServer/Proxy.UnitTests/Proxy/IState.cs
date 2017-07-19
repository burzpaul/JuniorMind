using System;

namespace Proxy.UnitTests
{
    internal interface IState
    {
        void Feed(byte data, Action<IState> changeState);
    }
}
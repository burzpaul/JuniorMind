using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    public abstract class State
    {
        internal abstract void Handle(byte data, Action<State> state);
    }
}
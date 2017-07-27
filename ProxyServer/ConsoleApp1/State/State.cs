using System;

namespace Proxy
{
    public abstract class State
    {
        internal abstract void Handle(byte data, Action<State> state);
    }
}
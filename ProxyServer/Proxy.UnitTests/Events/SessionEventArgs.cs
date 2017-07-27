using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests.Events
{
    internal class SessionEventArgs : EventArgs, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
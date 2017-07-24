using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.UnitTests
{
    public abstract class ChunkState
    {
        internal abstract void Handle(byte data, Action<ChunkState> state);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public abstract class ChunkState
    {
        internal abstract void Handle(byte bite, Action<ChunkState> state);
    }
}
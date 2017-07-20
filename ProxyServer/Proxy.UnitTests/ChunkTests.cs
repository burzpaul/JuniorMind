using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    internal class ChunkTests
    {
        [Fact]
        public void Something()
        {
            ChunkCompleteEventArgs a = new ChunkCompleteEventArgs();
            Chunk chunk = new Chunk();
            chunk.ChunkComplete += (object sender, ChunkCompleteEventArgs e) => a = e;

            Assert.Equal(a.Chunk, "YESSS");
        }
    }
}
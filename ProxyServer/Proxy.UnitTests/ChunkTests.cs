using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    public class ChunkTests
    {
        [Fact]
        public void Something()
        {
            ChunkCompleteEventArgs a = new ChunkCompleteEventArgs();
            Chunk chunk = new Chunk();
            chunk.ChunkComplete += (object sender, ChunkCompleteEventArgs e) => a = e;
            chunk.Something("a");

            Assert.Equal("YESSS", a.Chunk);
        }
    }
}
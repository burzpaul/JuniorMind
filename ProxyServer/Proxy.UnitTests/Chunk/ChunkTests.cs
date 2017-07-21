using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    public class ChunkTests
    {
        [Fact]
        public void Should_Return_True_For_Chunk_With_LowerCase_Hexa()
        {
            bool result = false;
            byte[] testData = Encoding.UTF8.GetBytes("4\r\nWiki\r\n5\r\npedia\r\ne\r\n in\r\n\r\nchunks.\r\n0\r\n\r\n");

            Chunk chunk = new Chunk();
            chunk.ChunkCompleted += (sender, e) => result = e.IsComplete;
            chunk.ProcessChunk(testData);

            Assert.Equal(true, result);
        }

        [Fact]
        public void Should_Return_True_For_Chunk_With_UpperCase_Hexa()
        {
            bool result = false;
            byte[] testData = Encoding.UTF8.GetBytes("4\r\nWiki\r\n5\r\npedia\r\nE\r\n in\r\n\r\nchunks.\r\n0\r\n\r\n");

            Chunk chunk = new Chunk();
            chunk.ChunkCompleted += (sender, e) => result = e.IsComplete;
            chunk.ProcessChunk(testData);

            Assert.Equal(true, result);
        }

        [Fact]
        public void Should_Return_True_For_Empty_Chunk()
        {
            bool result = false;
            byte[] testData = Encoding.UTF8.GetBytes("0\r\n\r\n");

            Chunk chunk = new Chunk();
            chunk.ChunkCompleted += (sender, e) => result = e.IsComplete;
            chunk.ProcessChunk(testData);

            Assert.Equal(true, result);
        }

        [Fact]
        public void Should_Return_False()
        {
            bool result = true;
            byte[] testData = Encoding.UTF8.GetBytes("1\r\nAA\r\n");

            Chunk chunk = new Chunk();
            chunk.ChunkCompleted += (sender, e) => result = e.IsComplete;
            chunk.ProcessChunk(testData);

            Assert.Equal(false, result);
        }
    }
}
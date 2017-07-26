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
            bool complete = false;

            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                "Transfer-Encoding: chunked\r\n\r\n" +
                "4\r\nWiki\r\n5\r\npedia\r\ne\r\n in\r\n\r\nchunks.\r\n0\r\n\r\n");

            Controller controller = new Controller();
            controller.ChunkCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(true, complete);
        }

        [Fact]
        public void Should_Return_True_For_Chunk_With_UpperCase_Hexa()
        {
            bool complete = false;

            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                "Transfer-Encoding: chunked\r\n\r\n" +
                "4\r\nWiki\r\n5\r\npedia\r\nE\r\n in\r\n\r\nchunks.\r\n0\r\n\r\n");

            Controller controller = new Controller();
            controller.ChunkCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(true, complete);
        }

        [Fact]
        public void Should_Return_True_For_Empty_Chunk()
        {
            bool complete = false;

            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                "Transfer-Encoding: chunked\r\n\r\n" +
                "0\r\n\r\n");

            Controller controller = new Controller();
            controller.ChunkCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(true, complete);
        }

        [Fact]
        public void Should_Return_False()
        {
            bool complete = false;

            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                "Transfer-Encoding: chunked\r\n\r\n" +
                "1\r\nAA\r\n");

            Controller controller = new Controller();
            controller.ChunkCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal("New line did not respect the protocol.Invalid length, smaller.", "true");
        }
    }
}
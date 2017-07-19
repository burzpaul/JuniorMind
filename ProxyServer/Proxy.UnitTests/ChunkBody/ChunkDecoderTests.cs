using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    public class ChunkBodyTests
    {
        [Fact]
        public void Should_trigger_complete_event_when_receiving_a_zero_size_chunk()
        {
            var chunkedBody = new ChunkBody();
            var isComplete = false;
            chunkedBody.OnComplete += () => isComplete = true;
            chunkedBody.Feed(Encoding.UTF8.GetBytes("0\r\n\r\n"));

            Assert.True(isComplete);
        }

        [Fact]
        public void Should_NOT_trigger_complete_only_a_single_chunck()
        {
            var chunkedBody = new ChunkBody();
            var isComplete = false;
            chunkedBody.OnComplete += () => isComplete = true;
            chunkedBody.Feed(Encoding.UTF8.GetBytes("4\r\nTest\r\n0\r\n\r\n"));

            Assert.False(isComplete);
        }

        [Fact]
        public void Should_Trigger_Exception_Protocol_Violation_CR_Expected()
        {
            var chunkedBody = new ChunkBody();
            var isComplete = false;
            chunkedBody.OnComplete += () => isComplete = true;

            chunkedBody.Feed(Encoding.UTF8.GetBytes("4\r34\nTest\r\n"));

            Assert.False(isComplete);
        }
    }
}
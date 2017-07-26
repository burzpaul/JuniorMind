using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    public class BodyTests
    {
        [Fact]
        public void Should_Return_True()
        {
            bool complete = false;

            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                "Content-Length: 9\r\n\r\n" +
                "Wikipedia\r\n\r\n");

            Controller controller = new Controller();
            controller.BodyCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(true, complete);
        }
    }
}
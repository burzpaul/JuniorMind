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

        [Fact]
        public void Should_Be_False()
        {
            bool complete = false;

            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                "Content-Length: 91\r\n\r\n" +
                "Wikipedia\r\n\r\n");

            Controller controller = new Controller();
            controller.BodyCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(false, complete);
        }

        [Fact]
        public void Should_Work()
        {
            bool complete = false;

            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\nDate: Wed, 26 Jul 2017 13:33:29 GMT\r\nServer: Apache\r\nLast-Modified: Sun, 06 Sep 2015 19:50:16 GMT\r\nAccept-Ranges: bytes\r\nContent-Length: 499\r\nContent-Type: text/css\r\n\r\n@charset \"utf-8\";\r\n/* CSS Document */\r\n\r\n::selection {\r\n\tcolor:#ffffff;\r\n\tbackground-color:#63b1be;\r\n}\r\n::-moz-selection {\r\n\tcolor:#ffffff;\r\n\tbackground-color:#63b1be;\r\n}\r\n#liteaccordion ol li > h2 > span.slide_name {\r\n\t-ms-filter:\"progid:DXImageTransform.Microsoft.BasicImage(rotation=1)\";\r\n\tfilter:progid:DXImageTransform.Microsoft.BasicImage(rotation=1);\r\n}\r\n.service-2 .icon img {\r\n\tfilter:alpha(opacity=70);\r\n}\r\n.service-2:hover .icon img {\r\n\tfilter:alpha(opacity=100);\r\n}\r\n.tabs {\r\n\tzoom:1;\r\n}");

            Controller controller = new Controller();
            controller.BodyCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(false, complete);
        }
    }
}
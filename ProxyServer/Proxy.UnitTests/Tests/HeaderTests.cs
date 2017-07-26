using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    public class HeaderTests
    {
        [Fact]
        public void Should_Return_True_For_Request_Header()
        {
            bool complete = false;
            byte[] testData = Encoding.UTF8.GetBytes("GET http://juniormind.com HTTP/1.1\r\nHost: juniormind.com\r\nProxy-Connection: keep-alive\r\nPragma: no-cache\r\nCache-Control: no-cache\r\nUpgrade-Insecure-Requests: 1\r\nUser-Agent: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8\r\nDNT: 1\r\nAccept-Encoding: gzip, deflate\r\nAccept-Language: en-GB,en-US;q=0.8,en;q=0.6\r\nCookie: MSID=ce9be95e-f8b6-42ad-bd9e-7148ee830ec5; _ga=GA1.2.1485718505.1498636596; _gid=GA1.2.927427221.1500888954\r\n\r\n");

            Controller controller = new Controller();
            controller.HeaderCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(true, complete);
        }

        [Fact]
        public void Should_Return_True_For_Response_Header()
        {
            bool complete = false;
            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/css; charset=utf-8\r\n" +
                "Access-Control-Allow-Origin: *\r\n" +
                "Timing-Allow-Origin: *\r\n" +
                "Link: <http://fonts.gstatic.com>; rel=preconnect; crossorigin\r\n" +
                "Expires: Fri, 21 Jul 2017 12:11:35 GMT\r\n" +
                "Date: Fri, 21 Jul 2017 12:11:35 GMT\r\n" +
                "Cache-Control: private, max-age=86400, stale-while-revalidate=604800\r\n" +
                "Last-Modified: Fri, 21 Jul 2017 12:11:35 GMT\r\n" +
                "Content-Encoding: gzip\r\n" +
                "Transfer-Encoding: chunked\r\n" +
                "Server: ESF\r\nX-XSS-Protection: 1; mode=block\r\nX-Frame-Options: SAMEORIGIN\r\n\r\n");

            Controller controller = new Controller();
            controller.HeaderCompleted += (sender, e) => complete = e.IsComplete;
            controller.Feed(testData);

            Assert.Equal(true, complete);
        }

        [Fact]
        public void Should_Return_Host()
        {
            string field = string.Empty;
            string field2 = string.Empty;
            byte[] testData = Encoding.UTF8.GetBytes("GET http://juniormind.com HTTP/1.1\r\nHost: juniormind.com\r\nProxy-Connection: keep-alive\r\nPragma: no-cache\r\nCache-Control: no-cache\r\nUpgrade-Insecure-Requests: 1\r\nUser-Agent: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8\r\nDNT: 1\r\nAccept-Encoding: gzip, deflate\r\nAccept-Language: en-GB,en-US;q=0.8,en;q=0.6\r\nCookie: MSID=ce9be95e-f8b6-42ad-bd9e-7148ee830ec5; _ga=GA1.2.1485718505.1498636596; _gid=GA1.2.927427221.1500888954\r\n\r\n");
            Controller controller = new Controller();
            controller.HeaderCompleted += (sender, e) =>
            {
                field = e.HeaderFields.Get("Host");
                e.HeaderFields.Set("Pragma", "Changed");
                field2 = e.HeaderFields.Get("Pragma");
            };
            controller.Feed(testData);

            Assert.Equal("juniormind.com", field);
            Assert.Equal("Changed", field2);
        }

        [Fact]
        public void Should_Return_200_OK_And_Chuncked()
        {
            string field = string.Empty;
            string field2 = string.Empty;
            byte[] testData = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n" +
                            "Content-Type: text/css; charset=utf-8\r\n" +
                            "Access-Control-Allow-Origin: *\r\n" +
                            "Timing-Allow-Origin: *\r\n" +
                            "Link: <http://fonts.gstatic.com>; rel=preconnect; crossorigin\r\n" +
                            "Expires: Fri, 21 Jul 2017 12:11:35 GMT\r\n" +
                            "Date: Fri, 21 Jul 2017 12:11:35 GMT\r\n" +
                            "Cache-Control: private, max-age=86400, stale-while-revalidate=604800\r\n" +
                            "Last-Modified: Fri, 21 Jul 2017 12:11:35 GMT\r\n" +
                            "Content-Encoding: gzip\r\n" +
                            "Transfer-Encoding: chunked\r\n" +
                            "Server: ESF\r\nX-XSS-Protection: 1; mode=block\r\nX-Frame-Options: SAMEORIGIN\r\n\r\n");

            Controller controller = new Controller();
            controller.HeaderCompleted += (sender, e) =>
            {
                field = e.HeaderFields.Get("Status Code");
                field2 = e.HeaderFields.Get("Transfer-Encoding");
            };
            controller.Feed(testData);

            Assert.Equal("200 OK", field);
            Assert.Equal("chunked", field2);
        }

        [Fact]
        public void Should_Return_Modified_Header()
        {
            var result = string.Empty;
            var testData = "GET http://juniormind.com HTTP/1.1\r\nHost: juniormind.com\r\nProxy-Connection: keep-alive\r\nPragma: no-cache\r\nCache-Control: no-cache\r\nUpgrade-Insecure-Requests: 1\r\nUser-Agent: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8\r\nDNT: 1\r\nAccept-Encoding: gzip, deflate\r\nAccept-Language: en-GB,en-US;q=0.8,en;q=0.6\r\nCookie: MSID=ce9be95e-f8b6-42ad-bd9e-7148ee830ec5; _ga=GA1.2.1485718505.1498636596; _gid=GA1.2.927427221.1500888954\r\n\r\n";
            var expected = "GET http://juniormind.com HTTP/1.1\r\nHost: juniormind.com\r\n";
            byte[] byteTestData = Encoding.UTF8.GetBytes(testData);

            Controller controller = new Controller();
            controller.HeaderCompleted += (sender, e) => result = e.HeaderFields.GetRequest;

            controller.Feed(byteTestData);

            Assert.Equal(expected, result);
        }
    }
}
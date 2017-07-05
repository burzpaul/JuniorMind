using System;
using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string a = "HTTP/1.1 200 OK\r\nDate: Thu, 29 Jun 2017 10:31:03 GMT\r\nServer: Apache\r\nX-Powered-By: PHP/5.3.23\r\nX-Pingback: http://juniormind.com/xmlrpc.php\r\nLink: <http://juniormind.com/>; rel=shortlink\r\nContent-Length: 17940\r\nContent-Type: text/html; charset=UTF-8\r\nSet-Cookie: MSID=ce9be95e-f8b6-42ad-bd9e-7148ee830ec5; path=/\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en-US\">\r\n<head>\r\n\r\n\t============ ";
            var responseHeader = a.Split(new string[] { "\r\n\r\n" }, 2, StringSplitOptions.None)[0];

            Assert.Equal(responseHeader, "1");
        }
    }
}
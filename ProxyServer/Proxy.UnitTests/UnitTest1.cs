using System.Text;
using Xunit;

namespace Proxy.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var responseMessage = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\nDate: Tue, 27 Jun 2017 12:30:56 GMT\r\nServer: Apache\r\nX-Powered-By: PHP/5.3.23\r\nX-Pingback: http://juniormind.com/xmlrpc.php\r\nLink: <http://juniormind.com/>; rel=shortlink\r\nContent-Length: 17940\r\nContent-Type: text/html; charset=UTF-8\r\n\r\n< !DOCTYPE html >\r\n < html lang =\"en-US\">\r\n<head>\r\n\r\n\t<!-- Basic meta tags\r\n\t================================================== -->\r\n\t<meta charset=\"UTF-8\" />\r\n\t<meta name=\"keywords\" content=\" , JuniorMind , JuniorMind Website &#8211; Training and Recruiting\" />\r\n\t<meta name=\"description\" content=\" | JuniorMind Website &#8211; Training and Recruiting\" />\r\n\t<meta name=\"author\" content=\"\" />\r\n\t<meta name=\"viewport\" content=\"initial-scale=1.0, width=device-width\" />\r\n\t\r\n\t<title>JuniorMind</title>\r\n\t\r\n\t<link rel=\"pingback\" href=\"http://juniormind.com/xmlrpc.php\" />\r\n\t\r\n\t<!-- Favicon\r\n\t================================================== -->\r\n\t\t<link rel=\"shortcut icon\" href=\"http://juniormind.com/wp-content/uploads/2015/11/favicon.ico\" type=\"image/x-icon\" />\r\n\t<link href=\"http://fonts.googleapis.com/css?family=Philosopher:400,700,400italic,700italic\" rel=\"stylesheet\" type=\"text/css\">\r\n\t\r\n\t<link rel=\"alternate\" type=\"application/rss+xml\" title=\"JuniorMind &raquo; Feed\" href=\"http://juniormind.com/feed/\" />\n<link rel=\"alternate\" type=\"application/rss+xml\" title=\"JuniorMind &raquo; Comments Feed\" href=\"http://juniormind.com/comments/feed/\" />\n\t\t<script type=\"text/javascript\">\n\t\t\twindow._wpemojiSettings = {\"baseUrl\":\"http:\\/\\/s.w.org\\/images\\/core\\/emoji\\/72x72\\/\",\"ext\":\".png\",\"source\":{\"concatemoji\":\"http:\\/\\/juniormind.com\\/wp-includes\\/js\\/wp-emoji-release.min.js?ver=4.3.11\"}};\n\t\t\t!function(a,b,c){function d(a){var c=b.createElement(\"canvas\"),d=c.getContext&&c.getContext(\"2d\");return d&&d.fillText?(d.textBaseline=\"top\",d.font=\"600 32px Arial\",\"flag\"===a?(d.fillText(String.fromCharCode(55356,56812,55356,56807),0,0),c.toDataURL().length>3e3):(d.fillText(String.fromCharCode(55357,56835),0,0),0!==d.getImageData(16,16,1,1).data[0])):!1}function e(a){var c=b.createElement(\"script\");c.src=a,c.type=\"text/javascript\",b.getElementsByTagName(\"head\")[0].appendChild(c)}var f,g;c.supports={simple:d(\"simple\"),flag:d(\"flag\")},c.DOMReady=!1,c.readyCallback=function(){c.DOMReady=!0},c.supports.simple&&c.supports.flag||(g=function(){c.readyCallback()},b.addEventListener?(b.addEventListener(\"DOMContentLoaded\",g,!1),a.addEventListener(\"load\",g,!1)):(a.attachEvent(\"onload\",g),b.attachEvent(\"onreadystatechange\",function(){\"complete\"===b.readyState&&c.readyCallback()})),f=c.source||{},f.concatemoji?e(f.concatemoji):f.wpemoji&&f.twemoji&&(e(f.twemoji),e(f.wpemoji)))}(window,document,window._wpemojiSettings);\n\t\t</script>\n\t\t<style type=\"text/css\">\nimg.wp-smiley,\nimg.emoji {\n\tdisplay: inline !important;\n\tborder: none !important;\n\tbox-shadow: none !important;\n\theight: 1em !important;\n\twidth: 1em !important;\n\tmargin: 0 .07em !important;\n\tvertical-align: -0.1em !important;\n\tbackground: none !important;\n\tpadding: 0 !important;\n}\n</style>\n<link rel='stylesheet' id='unique-style-css'  href='http://juniormind.com/wp-content/themes/unique/style.css?ver=4.3.11' type='text/css' media='all' />\n<link rel='stylesheet' id='normalize-css'  href='http://juniormind.com/wp-content/themes/unique/css/normalize.css' type='text/css' media='all' />\n<link rel='stylesheet' id='960-css'  href='http://juniormind.com/wp-content/themes/unique/css/960.css' type='text/css' media='all' />\n<link rel='stylesheet' id='superfish-css'  href='http://juniormind.com/wp-content/themes/unique/css/superfish.css' type='text/css' media='all' />\n<link rel='stylesheet' id='prettyPhoto-css'  href='http://juniormind.com/wp-content/themes/unique/css/prettyPhoto.css' type='text/css' media='all' />\n<link rel='stylesheet' id='fix-css'  href='http://juniormind.com/wp-content/themes/unique/css/fix.css' type='text/css' media='all' />\n<link rel='stylesheet' id='tipsy-css'  href='http://juniormind.com/wp-content/themes/unique/css/tipsy.css' type='text/css' media='all' />\n<link rel='stylesheet' id='style-css'  href='http://juniormind.com/wp-content/themes/juniormind-un");
            var equal = "HTTP/1.1 200 OK\r\nDate: Tue, 27 Jun 2017 12:30:56 GMT\r\nServer: Apache\r\nX-Powered-By: PHP/5.3.23\r\nX-Pingback: http://juniormind.com/xmlrpc.php\r\nLink: <http://juniormind.com/>; rel=shortlink\r\nContent-Length: 17940\r\nContent-Type: text/html; charset=UTF-8\r\n\r\n";

            var responseHandler = new ResponseHandler();

            var headerService = new HeaderService();

            var bodyService = new BodyService();

            responseHandler.HeadersComplete += headerService.OnHeadersCompleted;

            responseHandler.HeadersComplete += bodyService.OnBodyChunkReceived;

            responseHandler.HandleResponse(responseMessage);

            Assert.Equal(equal, headerService.header.GetFullHeader());
        }

        [Fact]
        public void Test2()
        {
        }
    }
}
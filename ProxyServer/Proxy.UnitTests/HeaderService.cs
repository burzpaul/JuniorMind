using System;
using System.Text;

namespace Proxy.UnitTests
{
    public class HeaderService
    {
        public Headers header { get; set; }

        public void OnHeadersCompleted(object source, ResponseEventsArgs e)
        {
            header = new Headers(Encoding.UTF8.GetString(e.Response));
        }
    }
}
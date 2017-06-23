using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Xunit;

namespace Proxy
{
    public class Headers
    {
        private string rawHeader;
        private Dictionary<string, string> headerFields;

        public Headers(string data)
        {
            this.rawHeader = data;
            this.headerFields = new Dictionary<string, string>();
            ProcessRawHeader();
        }

        public string this[string key]
        {
            get
            {
                return headerFields[key];
            }
        }

        public string GetFullHeader()
        {
            return headerFields.Select(x => x.Value).Aggregate((x1, x2) => x1 + x2) + "\r\n";
        }

        private void ProcessRawHeader()
        {
            var splitRawHeaders = rawHeader.Replace("\r\n", "\n").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in splitRawHeaders)
            {
                headerFields.Add(field.Split(' ')[0].Replace(":", ""), (field.IndexOf("http://") != -1 ? ProcessString(field) : field) + "\r\n");
            }
        }

        private string ProcessString(string field)
        {
            field = field.Replace("http://", "");
            var from = field.IndexOf(" ") + 1;
            var to = field.IndexOf("/");
            field = field.Remove(from, to - from);
            return field;
        }
    }
}
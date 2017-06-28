using System;
using System.Linq;
using System.Collections.Generic;

namespace Proxy.UnitTests
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
            return headerFields.Select(x => x.Value).Aggregate((x1, x2) => x1 + x2);
        }

        private void ProcessRawHeader()
        {
            var splitRawHeaders = rawHeader.Replace("\r\n", "\n").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in splitRawHeaders)
            {
                if (field.Contains("GET") || field.Contains("POST"))
                {
                    headerFields.Add("Request", ProcessString(field) + "\r\n");
                }
                else
                {
                    headerFields.Add(field.Split(' ')[0].Replace(":", ""), field + "\r\n");
                }
            }
            headerFields.Add("EOL", "\r\n");
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
using System;
using System.Linq;
using System.Collections.Generic;

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
            return headerFields.Select(x => x.Value).Aggregate((x1, x2) => x1 + x2);
        }

        private void ProcessRawHeader()
        {
            var splitRawHeaders = rawHeader.Replace("\r\n", "\n").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in splitRawHeaders)
            {
                if (field.Contains("HTTP/1.1"))
                {
                    int number;
                    if (Int32.TryParse(field.Split(' ')[1], out number))
                    {
                        headerFields.Add("Method", field.Split(' ')[0] + "\r\n");
                        headerFields.Add("Status Code", field.Split(' ')[1][2] + "\r\n");
                    }
                    else
                    {
                        headerFields.Add("Method", ProcessString(field) + "\r\n");
                    }
                }
                else
                {
                    headerFields.Add(field.Split(' ')[0].Replace(":", ""), field + "\r\n");
                }
            }
            headerFields.Add("EOL", "\r\n\r\n");
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
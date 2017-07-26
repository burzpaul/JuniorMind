using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    public class HeaderFields
    {
        private Dictionary<string, string> headerFields = new Dictionary<string, string>();
        private string rawData;
        private string request;

        public void AddChar(char data)
        {
            rawData += data;
        }

        public string Get(string name)
        {
            return headerFields.ContainsKey(name) == true ? headerFields[name] : string.Empty;
        }

        public void Set(string name, string value)
        {
            headerFields[name] = value;
        }

        public byte[] GetModifiedHeader => Encoding.UTF8.GetBytes(rawData.Replace("http://" + headerFields["Host"], "/"));

        public string GetRequest => request;

        public void ProcessRawData()
        {
            var fields = rawData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            request = fields[0] + "\r\n" + fields[1] + "\r\n";

            foreach (var field in fields)
            {
                if (field.Split(' ')[0].Contains("GET") || field.Split(' ')[0].Contains("POST"))
                {
                    var splitField = field.Split(' ');
                    headerFields.Add("Request Method", splitField[0]);
                    headerFields.Add("Abosult Uri", splitField[1]);
                    headerFields.Add("Protocol", splitField[2]);
                }
                else if (field.Split(' ')[0].Contains("HTTP"))
                {
                    var splitField = field.Split(' ');
                    headerFields.Add("Protocol", splitField[0]);
                    headerFields.Add("Status Code", splitField[1] + " " + splitField[2]);
                }
                else
                {
                    var splitField = field.Split(':');

                    headerFields.Add(splitField[0], splitField[1].Trim());
                }
            }
        }
    }
}
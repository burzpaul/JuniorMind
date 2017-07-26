using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
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

        public void ProcessRawData()
        {
            List<string> fields = new List<string>();

            fields.AddRange(rawData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            ProcessFirstLine(fields[0].Split(' '));

            fields.RemoveAt(0);

            foreach (var field in fields)
            {
                var split = field.Split(':');

                headerFields.Add(split[0], split[1].Trim());
            }
        }

        private void ProcessFirstLine(string[] splitField)
        {
            if (splitField[0].Contains("GET") || splitField[0].Contains("POST"))
            {
                request = splitField[0] + " " + splitField[1];

                headerFields.Add("Request Method", splitField[0]);
                headerFields.Add("Abosult Uri", splitField[1]);
                headerFields.Add("Protocol", splitField[2]);
            }
            else
            {
                headerFields.Add("Protocol", splitField[0]);
                headerFields.Add("Status Code", splitField[1] + " " + splitField[2]);
            }
        }

        public string Get(string name)
        {
            return headerFields[name];
        }

        public bool ContainsKey(string name)
        {
            return Find(name) == 1 ? true : false;
        }

        private int Find(string name)
        {
            foreach (var item in headerFields)
            {
                if (name == item.Key)
                    return 1;
            }
            return -1;
        }

        public void Set(string name, string value)
        {
            headerFields[name] = value;
        }

        public byte[] GetModifiedRequest => Encoding.UTF8.GetBytes(rawData.Replace("http://" + headerFields["Host"], ""));

        public byte[] GetResponsHeader => Encoding.UTF8.GetBytes(rawData);

        public string GetRequest => request;
    }
}
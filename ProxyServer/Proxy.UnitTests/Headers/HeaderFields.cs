using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests.Headers
{
    public class HeaderFields
    {
        private Dictionary<string, string> headerFields = new Dictionary<string, string>();
        private string rawData;

        public void AddField(char data)
        {
            rawData += data;
        }

        public void Something(string a)
        {
            headerFields["Host"] = "asa";
        }

        private String this[string key]
        {
            get
            {
                if (headerFields.ContainsKey(key))
                {
                    return headerFields[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                headerFields[key] = value;
            }
        }

        public void ProcessRawData()
        {
            var fields = rawData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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
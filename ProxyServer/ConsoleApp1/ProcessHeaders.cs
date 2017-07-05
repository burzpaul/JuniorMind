using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ProcessHeaders
    {
        private string rawHeader;
        private Dictionary<string, string> headerFields;

        public ProcessHeaders(string request)
        {
            rawHeader = request;
            headerFields = new Dictionary<string, string>();
            ProcessingRawHeader();
        }

        public String this[string key]
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
        }

        private void ProcessingRawHeader()
        {
            var listHeaderFields = rawHeader.Replace("\r\n", "\n").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (listHeaderFields[0].Contains("GET") || listHeaderFields[0].Contains("POST"))
            {
                headerFields.Add("Request Method", listHeaderFields[0].Split(' ')[0]);
                headerFields.Add("Absolut Uri", listHeaderFields[0]);
            }
            else
            {
                headerFields.Add("Status Code", listHeaderFields[0].Split(' ')[1]);
            }
            listHeaderFields.RemoveAt(0);

            foreach (var field in listHeaderFields)
            {
                var key = field.Split(':')[0];
                var value = field.Split(':')[1].Trim();

                headerFields.Add(key, value);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests.NewFolder1
{
    public class Header
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Header(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name cannot be null");
            }
            Name = name;
            Value = value;
        }

        public string HeaderString()
        {
            return $"{Name}: {Value}";
        }
    }
}
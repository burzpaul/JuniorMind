using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class PasswordInfo
    {
        public int NumberOfPasswords { get; set; }
        public int PasswordLength { get; set; }
        public int UpperCase { get; set; }
        public int Digits { get; set; }
        public int Symbols { get; set; }
        public bool ExcludeSimilar { get; set; }
        public bool ExcludeAmbigous { get; set; }
    }
}
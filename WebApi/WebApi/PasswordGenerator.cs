using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class PasswordGenerator
    {
        private PasswordInfo info;
        private Random rand = new Random();

        public PasswordGenerator(PasswordInfo info)
        {
            this.info = info;
        }

        public string[] GeneratePassword()
        {

            string[] passwords = new string[info.Number];
            passwords = Enumerable.Range(0, info.Number).Select(x => GenerateOnePassword()).ToArray();
            return passwords;
        }

        private string GenerateOnePassword()
        {
            var password = GetCharacters((info.PasswordLength - info.UpperCase - info.Symbols - info.Digits), 'a', 'z', info.ExcludeSimilar) +
                            GetCharacters(info.UpperCase, 'A', 'Z', info.ExcludeSimilar) +
                            GetSymbols(info.Symbols, info.ExcludeAmbigous) +
                            GetCharacters(info.Digits, '0', '9', info.ExcludeSimilar);

            var shuffled = Shuffle(password);
            return password;
        }

        private string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            for (int i = 0; i <= rand.Next(); i++)
            {
                rand.Next();
            }
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        private string GetCharacters(int numberOfCharacters, char bottomBoundry, char upperBoundry, bool var)
        {
            string result = null;
            char temporaryHolder;
            string specialCharacters = "l1Io0O";
            for (int i = 0; i < numberOfCharacters; i++)
            {
                temporaryHolder = (char)rand.Next(bottomBoundry, upperBoundry);
                if (var == true && specialCharacters.IndexOf(temporaryHolder) != -1)
                {
                    i--;
                    continue;
                }
                result += temporaryHolder;
            }
            return result;
        }
        private string GetSymbols(int numberOfSymbols, bool var)
        {
            string symbols = "!#$%&'()*+,-./:;<=>?@[]^_`{|}~";
            string specialSymbols = "{}[]()/\'~,;.<>";
            char temporaryHolder;
            string result = null;
            for (int i = 0; i < numberOfSymbols; i++)
            {
                temporaryHolder = symbols[rand.Next(0, 30)];
                if (var == true && specialSymbols.IndexOf(temporaryHolder) != -1)
                {
                    i--;
                    continue;
                }
                result += temporaryHolder;
            }
            return result;
        }
    }
}

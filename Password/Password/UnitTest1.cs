using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Password
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckLowerCaseLettersPassword()
        {
            var password = GeneratePassword(new Password(8, 8, 0, 0, 0, false, false));
            Assert.AreEqual(8 , Counter(password,'a','z'));
        }
        [TestMethod]
        public void CheckUpperCaseLettersPassword()
        {
            var password = GeneratePassword(new Password(10, 0, 10, 0, 0, false, false));
            Assert.AreEqual(10, Counter(password, 'A', 'Z'));
        }
       [TestMethod]
        public void CheckDigitsPassword()
        {
            var password = GeneratePassword(new Password(6, 0, 0, 6, 0, false, false));
            Assert.AreEqual(6, Counter(password, '0', '9'));
        }
        [TestMethod]
        public void CheckSymbolsPassword()
        {
            var password = GeneratePassword(new Password(4, 0, 0, 0, 4, false, false));
            Assert.AreEqual(4, NumberOfSymbols(password));
        }
        [TestMethod]
        public void PasswordWithoutSimilarOrAmbiguousCharacters()
        {
            var password = GeneratePassword(new Password(50, 10, 20, 10, 10, true, true));
            Assert.AreEqual(true, PasswordWithoutSimilarOrAmbiguousCharacters(password));
        }
        struct Password
        {
            public int passwordLength;
            public int lowerCaseLetters;
            public int upperCaseLetters;
            public int digits;
            public int symbols;
            public bool exludeSimilarCharacters;
            public bool excludeAmbiguousCharacters;
            public Password(int passwordLength, int lowerCaseLetters, int upperCaseLetters, int digits, int symbols, bool exludeSimilarCharacters, bool excludeAmbiguousCharacters)
            {
                this.passwordLength = passwordLength;
                this.lowerCaseLetters = lowerCaseLetters;
                this.upperCaseLetters = upperCaseLetters;
                this.digits = digits;
                this.symbols = symbols;
                this.exludeSimilarCharacters = exludeSimilarCharacters;
                this.excludeAmbiguousCharacters = excludeAmbiguousCharacters;
            }
        }
        Random rand = new Random();
        string GeneratePassword(Password password)
        {
            string result = null;
            result += GetCharacters(password.lowerCaseLetters,'a','z',password.exludeSimilarCharacters);
            result += GetCharacters(password.upperCaseLetters, 'A', 'Z',password.exludeSimilarCharacters);
            result += GetCharacters(password.digits, '0', '9',password.exludeSimilarCharacters);
            result += GetSymbols(password.symbols,password.excludeAmbiguousCharacters);
            return result;
        }
        string GetSymbols(int numberOfSymbols,bool exclude)
        {
            string symbols = " !#$%&'()*+,-./:;<=>?@[]^_`{|}~";
            string specialSymbols = "{}[]()/\'~,;.<>";
            char temporaryHolder;
            string result = null;
            for (int i = 0; i < numberOfSymbols; i++)
            {
                temporaryHolder = symbols[rand.Next(0, 30)];
                if (exclude == true && specialSymbols.IndexOf(temporaryHolder) != -1)
                {
                    i--;
                    continue;
                }
                result += temporaryHolder;
            }
            return result;
        }
        string GetCharacters(int numberOfCharacters, char bottomBoundry, char upperBoundry,bool exclude)
        {
            string result = null;
            char temporaryHolder;
            string specialCharacters = "l1Io0O";
            for (int i = 0; i < numberOfCharacters; i++)
            {
                temporaryHolder = (char)rand.Next(bottomBoundry, upperBoundry);
                if (exclude == true && specialCharacters.IndexOf(temporaryHolder) != -1)
                {
                    i--;
                    continue;
                }
                result += temporaryHolder;
            }
            return result;
        }
        private int NumberOfSymbols(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
                if (!Char.IsLetterOrDigit(password[i]) )
                    count++;
            return count;
        }
        private int Counter(string password, char bottomBoundry ,char upperBoundry)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
                for (int j = bottomBoundry; j <= upperBoundry; j++)
                    if (password[i] == j)
                        count++;
            return count;
        }
        private bool PasswordWithoutSimilarOrAmbiguousCharacters(string password)
        {
            string searchedForCharacters = "l1Io0O{}[]()/\'~,;.<>";
            for (int i = 0; i < password.Length; i++)
                if (password.IndexOf(searchedForCharacters) != -1) 
                            return false;
            return true;
        }
    }
}

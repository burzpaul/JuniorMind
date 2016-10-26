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
            var password = GeneratePassword(new Password(8, 8, 0, 0, 0, 0, 0));
            Assert.AreEqual(8 , OnlyLowerCaseLetters(password));
        }
        [TestMethod]
        public void CheckUpperCaseLettersPassword()
        {
            var password = GeneratePassword(new Password(10, 0, 10, 0, 0, 0, 0));
            Assert.AreEqual(10, NumberOfUpperCaseLetters(password));
        }
       [TestMethod]
        public void CheckDigitsPassword()
        {
            var password = GeneratePassword(new Password(6, 0, 0, 6, 0, 0, 0));
            Assert.AreEqual(6, NumberOfDigits(password));
        }
        [TestMethod]
        public void CheckSymbolsPassword()
        {
            var password = GeneratePassword(new Password(4, 0, 0, 0, 4, 0, 0));
            Assert.AreEqual(4, NumberOfSymbols(password));
        }
        [TestMethod]
        public void PasswordWithoutSimilarOrAmbiguousCharacters()
        {
            var password = GeneratePassword(new Password(50, 10, 20, 10, 10, 1, 1));
            Assert.AreEqual(true, PasswordWithoutSimilarOrAmbiguousCharacters(password));
        }
        struct Password
        {
            public int passwordLength;
            public int lowerCaseLetters;
            public int upperCaseLetters;
            public int digits;
            public int symbols;
            public byte exludeSimilarCharacters;
            public byte excludeAmbiguousCharacters;
            public Password(int passwordLength, int lowerCaseLetters, int upperCaseLetters, int digits, int symbols, byte exludeSimilarCharacters, byte excludeAmbiguousCharacters)
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
            result += GetSymbols(password.symbols,password.exludeSimilarCharacters);
            return result;
        }
        string GetSymbols(int numberOfSymbols,byte var)
        {
            string symbols = " !#$%&'()*+,-./:;<=>?@[]^_`{|}~";
            string specialSymbols = "{}[]()/\'~,;.<>";
            char temporaryHolder;
            string result = null;
            for (int i = 0; i < numberOfSymbols; i++)
            {
                temporaryHolder = symbols[rand.Next(0, 30)];
                if (var == 1 && specialSymbols.IndexOf(temporaryHolder) != -1)
                {
                    i--;
                    continue;
                }
                result += temporaryHolder;
            }
            return result;
        }
        string GetCharacters(int numberOfCharacters, char bottomBoundry, char upperBoundry,byte var)
        {
            string result = null;
            char temporaryHolder;
            string specialCharacters = "l1Io0O";
            for (int i = 0; i < numberOfCharacters; i++)
            {
                temporaryHolder = (char)rand.Next(bottomBoundry, upperBoundry);
                if (var == 1 && specialCharacters.IndexOf(temporaryHolder) != -1)
                {
                    i--;
                    continue;
                }
                result += temporaryHolder;
            }
            return result;
        }
        private int NumberOfUpperCaseLetters(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length ; i++)
                if (Char.IsUpper(password[i]))
                    count++;
            return count;
        }
        private int NumberOfDigits(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
                if (Char.IsDigit(password[i]))
                    count++;
            return count;
        }
        private int NumberOfSymbols(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
                if (!Char.IsLetterOrDigit(password[i]) )
                    count++;
            return count;
        }
        private int OnlyLowerCaseLetters(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length  ; i++)
                if (Char.IsLower(password[i]))
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

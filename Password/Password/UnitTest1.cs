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
            var password = GeneratePassword(new Password(8,8,0,0,0));
            Assert.AreEqual(true , OnlyLowerCaseLetters(password));
        }
        [TestMethod]
        public void CheckUpperCaseLettersPassword()
        {
            var password = GeneratePassword(new Password(10, 0, 10, 0 , 0));
            Assert.AreEqual(10, NumberOfUpperCaseLetters(password));
        }
       [TestMethod]
        public void CheckDigitsPassword()
        {
            var password = GeneratePassword(new Password(6, 0, 0, 6, 0));
            Assert.AreEqual(6, NumberOfDigits(password));
        }
        [TestMethod]
        public void CheckSymbolsPassword()
        {
            var password = GeneratePassword(new Password(4, 0, 0, 0, 4));
            Assert.AreEqual(4, NumberOfSymbols(password));
        }
        struct Password
        {
            public int passwordLength;
            public int lowerCaseLetters;
            public int upperCaseLetters;
            public int digits;
            public int symbols;
            public Password(int passwordLength, int lowerCaseLetters, int upperCaseLetters, int digits, int symbols)
            {
                this.passwordLength = passwordLength;
                this.lowerCaseLetters = lowerCaseLetters;
                this.upperCaseLetters = upperCaseLetters;
                this.digits = digits;
                this.symbols = symbols;
            }
        }
        Random rand = new Random();
        string GeneratePassword(Password password)
        {
            string result = null;
            result += GetCharacters(password.lowerCaseLetters,'a','z');
            result += GetCharacters(password.upperCaseLetters, 'A', 'Z');
            result += GetCharacters(password.digits, '0', '9');
            result += GetSymbols(password.symbols);
            return result;
        }
        string GetSymbols(int numberOfSymbols)
        {
            string symbols = " !#$%&'()*+,-./:;<=>?@[]^_`{|}~";
            string result = null;
            for (int i = 0; i < numberOfSymbols; i++)
                result += symbols[rand.Next(0,30)];
            return result;
        }
        string GetCharacters(int numberOfCharacters, char start, char end)
        {
            string result = null;
            for (int i = 0; i < numberOfCharacters; i++)
                result += (char)rand.Next(start,end);
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
            string symbols = " !#$%&'()*+,-./:;<=>?@[]^_`{|}~";
            for (int i = 0; i < password.Length; i++)
                if (symbols.IndexOf(password[i]) != -1)
                    count++;
            return count;
        }
        private bool OnlyLowerCaseLetters(string password)
        {
            for (int i = 0; i < password.Length  ; i++)
                if (Char.IsUpper(password[i]))
                    return false;      
            return true;
        }
    }
}

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
            return result;
        }
        string GetCharacters(int numberOfCharacters, char start, char end)
        {
            string result = null;
            for (int i = 0; i <= numberOfCharacters; i++)
                result += (char)rand.Next(start,end);
            return result;
        }
        int NumberOfUpperCaseLetters(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length - 1; i++)
                if (Char.IsUpper(password[i]))
                    count++;
            return count;
        }
        private bool OnlyLowerCaseLetters(string password)
        {
            for (int i = 0; i < password.Length -1 ; i++)
                if (Char.IsUpper(password[i]))
                    return false;      
            return true;
        }
    }
}

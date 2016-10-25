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
            var password = GeneratePassword(new Password(8, "abcdefghijklmnopqrstuvwxyz"));
            Assert.AreEqual(true , OnlyLowerCaseLetter(password));
        }
        struct Password
        {
            public int passwordLength;
            public string lowerCaseLetters;
            public Password(int passwordLength,string lowerCaseLetters)
            {
                this.passwordLength = passwordLength;
                this.lowerCaseLetters = lowerCaseLetters;
               
            }
        }
        Random rand = new Random();
        string GeneratePassword(Password password)
        {
            string result = null;
            for (int i = 0; i < password.passwordLength; i++)
                result += password.lowerCaseLetters[rand.Next(0, 25)];

            return result;
        }
        private bool OnlyLowerCaseLetter(string password)
        {
            for (int i = 0; i < password.Length -1 ; i++)
            {
                if (Char.IsUpper(password[i]))
                    return false;
            }
            return true;
        }
    }
}

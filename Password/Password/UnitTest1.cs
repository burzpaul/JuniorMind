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
            var password = GeneratePassword(new Password(8));
            Assert.AreEqual(true , OnlyLowerCaseLetters(password));
        }
        struct Password
        {
            public int passwordLength;
            public Password(int passwordLength)
            {
                this.passwordLength = passwordLength;   
            }
        }
        Random rand = new Random();
        string GeneratePassword(Password password)
        {
            string result = null;
            for (int i = 0; i < password.passwordLength; i++)
                result += (char)rand.Next('a', 'z');
            return result;
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

using System;
using System.Linq;
using System.Collections;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Password
{
    public struct UserPassword {
        public string thePassword;
       
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }
        public string Characters = "abcdefghijklmnopqrstuvwxyz";
        public string generatedPassword;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public string Password(int passwordLength)
        {
          
            for (int i = 0; i < passwordLength; i++) 
             generatedPassword = generatedPassword + Characters[RandomValue()];
            
            return null;
        }
        public byte  RandomValue()
        {
            byte[] randomNumber = new byte[1];
            do
            {
                rngCsp.GetBytes(randomNumber);
            } while (randomNumber[0] > Characters.Length - 1);
            return randomNumber[0];
        }
    }
}

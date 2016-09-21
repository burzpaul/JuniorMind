using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GiveWords()
        {
            char[] name = { 'l', 'a', 'c' };
            Assert.AreEqual(6, AnagramCalculator(name));
        }
        int AnagramCalculator(char[] word)
        {
            int i, n = 1; 
             for (i = 1; i <= word.Length; i++) 
                    n = n * i; 
            return n;
        }
    }
}

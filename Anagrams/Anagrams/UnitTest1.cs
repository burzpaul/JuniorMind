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
            Assert.AreEqual(3, AnagramCalculator("ac"));
        }
        string AnagramCalculator(string word)
        {
            return null;
        }
    }
}

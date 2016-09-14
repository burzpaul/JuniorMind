using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CifreRomane
{
    [TestClass]
    public class CifreRomaneTests
    {
        [TestMethod]
        public void Number()
        {
            Assert.AreEqual("I", NumberInRomanNumerals(1));
        }

        string NumberInRomanNumerals(int number)
        {
            return "I";
        }
    }
}

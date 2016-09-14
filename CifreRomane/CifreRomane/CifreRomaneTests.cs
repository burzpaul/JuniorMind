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
            Assert.AreEqual("III", NumberInRomanNumerals(3));
        }

        string NumberInRomanNumerals(int number)
        {
            if (number >= 1) return "I" +NumberInRomanNumerals(number -1);

            else
                return null;
        }
    }
}

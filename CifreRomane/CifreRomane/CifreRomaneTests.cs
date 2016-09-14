using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CifreRomane
{
    [TestClass]
    public class CifreRomaneTests
    {
        [TestMethod]
        public void SingleDigitConversion()
        {
            Assert.AreEqual("IV", NumberInRomanNumerals(4));
        }
        [TestMethod]
        public void DoubleDigitConversion()
        {
            Assert.AreEqual("XXXII", NumberInRomanNumerals(32));
        }
        [TestMethod]
        public void TripleDigitConversion()
        {
            Assert.AreEqual("DCCLXII", NumberInRomanNumerals(762));
        }
        [TestMethod]
        public void QuadDigitNewMethod()
        {
            Assert.AreEqual("MMMCMXCIX", NumberInRomanNumerals(3999));
        }
        string NumberInRomanNumerals(int number)
        {
            string[] symbols = { "I", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XL", "L", "LX", "LXX", "LXXX", "XC", "C", "CD", "D", "DC", "DCC", "DCCC", "CM", "M" };

            return symbols[1];

            return null;
        }

        private bool IsNumberTripleDigit(int number)
        {
            return number >= 100;
        }

        private bool IsNumberDoubleDigit(int number)
        {
            return number >= 10 && number <100;
        }

        private bool IsNumberSingleDigit(int number)
        {
            return number < 10;
        }
    }
}

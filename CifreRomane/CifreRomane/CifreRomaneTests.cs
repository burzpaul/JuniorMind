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
        public void FourDigitConversion()
        {
            Assert.AreEqual("MMMCMXCIX", NumberInRomanNumerals(3999));
        }
        
        string NumberInRomanNumerals(int number)
        {
            string[] symbol = { "I","II","III", "IV", "V", "VI", "VII", "VIII", "IX"};
            string[] symbol1 = {"","X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] symbol2 = {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            int a, b, c;
                a = number % 10;
                b = number % 100 / 10;
                c = number % 1000 / 100;
            return symbol2[c] + symbol1[b] + symbol[a-1];
        }
        private bool IsNumberTripleDigit(int number)
        {
            return number >= 100 && number <1000;
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

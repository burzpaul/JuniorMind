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
            string[] symbol  = { "I","II","III", "IV", "V", "VI", "VII", "VIII", "IX"};
            string[] symbol1 = {"","X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] symbol2 = {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] symbol3 = {"", "M", "MM", "MMM" };
            int fourthDigit, thirdDigit , secondDigit, firstDigit;
                fourthDigit = number % 10;
                thirdDigit = number % 100 / 10;
                secondDigit = number % 1000 / 100;
                firstDigit = number % 10000 / 1000;
            return symbol3[firstDigit] + symbol2[secondDigit] + symbol1[thirdDigit] + symbol[fourthDigit-1];
        }
        
    }
}

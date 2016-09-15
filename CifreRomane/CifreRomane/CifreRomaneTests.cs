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
            Assert.AreEqual("I", NumberInRomanNumerals(1));
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
            string[] symbol = { "I","II","III", "IV", "V", "VI", "VII", "VIII", "IX","X"};
            int a, b;

            if (IsNumberSingleDigit(number))

                    return symbol[number-1];

            if (IsNumberDoubleDigit(number))
            {
                a = number % 10;
                b = number % 100 / 10;
                string sample = new String('X', b);
                return sample + symbol[a-1];
            }

            return null;
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

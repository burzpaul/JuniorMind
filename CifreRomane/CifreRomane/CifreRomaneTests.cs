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
            Assert.AreEqual("C", NumberInRomanNumerals(100));
        }
        string NumberInRomanNumerals(int number)
        {
            if(IsNumberSingleDigit(number))
            {
                if (number >= 9) return "IX" + NumberInRomanNumerals(number - 9);
                if (number >= 5) return "V" + NumberInRomanNumerals(number - 5);
                if (number >= 4) return "IV" + NumberInRomanNumerals(number - 4);
                if (number >= 1) return "I" + NumberInRomanNumerals(number - 1);
            }
            if(IsNumberDoubleDigit(number))
            {
                if (number >= 90) return "XC" + NumberInRomanNumerals(number - 90);
                if (number >= 50) return "L" + NumberInRomanNumerals(number - 50);  
                if (number >= 40) return "XL" + NumberInRomanNumerals(number - 40);
                if (number >= 10) return "X" + NumberInRomanNumerals(number - 10);
              
            }
            if(IsNumberTripleDigit(number))
            {
                if (number >= 100) return "C" + NumberInRomanNumerals(number - 100);
            }
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

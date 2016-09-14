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
            Assert.AreEqual("L", NumberInRomanNumerals(50));
        }

        string NumberInRomanNumerals(int number)
        {
            if (number >= 90) return "XC" + NumberInRomanNumerals(number - 90);

            if (number >= 50) return "L" + NumberInRomanNumerals(number - 50);

            if (number >= 40) return "XL" + NumberInRomanNumerals(number - 40);

            if (number >= 10) return "X" + NumberInRomanNumerals(number - 10);

            if (number >= 9) return "IX" + NumberInRomanNumerals(number - 9);

            if (number >= 5) return "V" + NumberInRomanNumerals(number - 5);

            if (number >= 4) return "IV" + NumberInRomanNumerals(number - 4);

            if (number >= 1) return "I" + NumberInRomanNumerals(number - 1);

            else
                return null;
        }
    }
}

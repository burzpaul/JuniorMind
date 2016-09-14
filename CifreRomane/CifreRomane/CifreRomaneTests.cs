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
            Assert.AreEqual("VII", NumberInRomanNumerals(7));
        }

        string NumberInRomanNumerals(int number)
        {
            if (number >= 9) return "IX" + NumberInRomanNumerals(number - 9);

            if (number >= 5) return "V" + NumberInRomanNumerals(number - 5);

            if (number >= 4) return "IV" + NumberInRomanNumerals(number - 4);

            if (number >= 1) return "I" + NumberInRomanNumerals(number - 1);

            else
                return null;
        }
    }
}

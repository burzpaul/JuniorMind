using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CifreRomane
{
    [TestClass]
    public class CifreRomaneTests
    {
        [TestMethod]
        public void ExactConversion()
        {
            Assert.AreEqual('I', NumberInRomanNumerals(1));
        }

        decimal NumberInRomanNumerals(int number)
        {
            char[] romanNumerals = { 'I', 'V', 'X', 'C' };
            if (number == 1)
                return romanNumerals[0];
            else
                return 0;
            
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExelColumns
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SingleLetterColumn()
        {
            Assert.AreEqual("D", DetermineExelColumn(4));
        }
        [TestMethod]
        public void DoubleLetterColum()
        {
            Assert.AreEqual("BA", DetermineExelColumn(53));
        }
        [TestMethod]
        public void TripleLetterColumns()
        {
            Assert.AreEqual("AAA", DetermineExelColumn(703));
        }
        string DetermineExelColumn(int number)
        {
            number--;
            String col = Convert.ToString((char)('A' + (number % 26)));
            while (number >= 26)
            {
                number = (number / 26) - 1;
                col = Convert.ToString((char)('A' + (number % 26))) + col;
            }
            return col;
        }
        
    }
}

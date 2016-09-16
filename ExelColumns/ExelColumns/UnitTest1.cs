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
            Assert.AreEqual("E", DetermineExelColumn(5));
        }
        string DetermineExelColumn(int n)
        {
            string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int i, count=0;
            for (i = 0; i <= 26; i++)
            {
                count++;
                if (count == n)
                    return alphabet[n - 1];
            }
            return null;
        }
    }
}

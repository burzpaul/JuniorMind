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
        [TestMethod]
        public void DoubleLetterColum()
        {
            Assert.AreEqual("BA", DetermineExelColumn(53));
        }
        [TestMethod]
        public void TripleLetterColumns()
        {
            Assert.AreEqual("LKB", DetermineExelColumn(8712));
        }
        string DetermineExelColumn(int n)
        {
            string[] alphabet = {"","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int i,j,k,count=0;
            for(k=0; k <= 26; k++)
                for (j = 0; j <= 26; j++)
                    for (i = 1; i <= 26; i++)
                    {
                        count++;
                        if (count == n)
                            return alphabet[k]+alphabet[j]+alphabet[i];
                    }
            return null;
        }
    }
}

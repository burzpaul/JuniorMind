using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loto6OutOf49
{

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CategoryI()
        {
            Assert.AreEqual(10, Chances (3,5 ));
        }
        decimal Chances(int guessedNumbers,int guessingNumbers)
        {

            return CalculateCombinations(guessingNumbers, guessedNumbers);
            
             
        }
        static decimal CalculateCombinations(decimal n, decimal k)
        {
            if (k == 0)
                return 1;
            else
            if (k > n)
                return 0;
            else
                return (CalculateCombinations(n - 1, k) + CalculateCombinations(n - 1, k - 1));
        }
    }
}

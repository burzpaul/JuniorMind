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
            Assert.AreEqual(13983816, Chances (6,49 ));
        }
        [TestMethod]
        public void CategoryII()
        {
            Assert.AreEqual(54200,84, Chances(5, 49));
        }
        [TestMethod]
        public void CategoryIII()
        {
            Assert.AreEqual(1032,39, Chances(4, 49));
        }
        [TestMethod]
        public void Bonus()
        {
            Assert.AreEqual(658008, Chances(5, 40));
        }
        int Chances(float guessedNumbers,float guessingNumbers)
        {
            
            if (guessingNumbers == 49)

                return CalculateCombinations(guessingNumbers, 6) / ((CalculateCombinations(6,guessedNumbers) * CalculateCombinations(43, 6 - guessedNumbers))) ;
            else
                return CalculateCombinations(guessingNumbers, 5) / ((CalculateCombinations(5, guessedNumbers) * CalculateCombinations(35, 5 - guessedNumbers)));

        }
        static int CalculateCombinations(double n, double k)
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

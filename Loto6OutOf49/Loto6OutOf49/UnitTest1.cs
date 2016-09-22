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
            Assert.AreEqual(13983816, Chances (6,6,49 ),1);
        }
        [TestMethod]
        public void CategoryII()
        {
            double expected= 54200.8372093023;
            double actual = Chances(5,6,49);
            double delta = 0.9;
            Assert.AreEqual(expected, actual,delta);
        }
        [TestMethod]
        public void CategoryIII()
        {
            double expected = 1032.39689922481;
            double actual = Chances(4,6,49);
            double delta = 0.44;
            Assert.AreEqual(expected,actual,delta);
        }
        [TestMethod]
        public void Bonus()
        {
            Assert.AreEqual(658008, Chances(5,5,40));
        }
        double Chances(double guessedNumbers, double possibleGuesses, double guessingNumbers)
        {
            
                return CalculateCombinations(guessingNumbers, possibleGuesses) / ((CalculateCombinations(possibleGuesses,guessedNumbers) * CalculateCombinations(guessingNumbers-possibleGuesses, possibleGuesses - guessedNumbers))) ;
      
 
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

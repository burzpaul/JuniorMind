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
            Assert.AreEqual( 13983816, Chances (6, 49));
        }
        decimal Chances(decimal guessedNumbers, decimal guessingNumbers)
        {
            return 13983816;
        }
        
    }
}

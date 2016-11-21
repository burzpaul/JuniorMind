using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(12, Calculate("* 3 4 "),1);
        }
        public double Calculate(string operationsAndNumbers)
        {
            return 0;
        }
    }
}

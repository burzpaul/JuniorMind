using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonnaci
{
    [TestClass]
    public class MyClass
    {
        [TestMethod]
        public void FibonacciTest1()
        {
            Assert.AreEqual(55, Fibonacci(11,0,1));
        }
        [TestMethod]
        public void FibonacciTest2()
        {
            Assert.AreEqual(0, Fibonacci(1, 0, 1));
        }
        [TestMethod]
        public void FibonacciTest3()
        {
            Assert.AreEqual(987, Fibonacci(17, 0, 1));
        }
        public int Fibonacci(int elementNumber,int previous,int current)
        {
            if (elementNumber == 1)
                return previous;
            else
                return Fibonacci(elementNumber - 1, current, previous + current);
        }
    }
}

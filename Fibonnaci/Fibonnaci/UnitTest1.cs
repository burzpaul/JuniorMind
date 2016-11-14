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
            Assert.AreEqual(55, Fibonacci(11));
        }
        [TestMethod]
        public void FibonacciTest2()
        {
            Assert.AreEqual(0, Fibonacci(1));
        }
        [TestMethod]
        public void FibonacciTest3()
        {
            Assert.AreEqual(987, Fibonacci(17));
        }
        public int Fibonacci(int n)
        {
            int previous = 0;
            int current = 1;
            return Fibonacci(n,  previous,  current);
        }
        public int Fibonacci(int elementNumber, int previous, int current)
        {
            return elementNumber == 1 ? previous : Fibonacci(elementNumber - 1, current, previous + current);
        }
    }
}

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
            
            Assert.AreEqual(12, Calculate("* 3 4"),1);
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(1549.41,Calculate("+ / * + 56 45 46 3 - 1 0.25"),1);
        }
        double Calculate(string s)
        {
            string[] elements = s.Split(' ');
            int i = 0;
            return Calculate(elements, ref i);
        }

        double Calculate(string[] elements, ref int i)
        {
            string currentElement = elements[i++];
            double result = 0;
            if (double.TryParse(currentElement, out result))
            {
                return result;
            }

            switch (currentElement)
            {
                case "+": return Calculate(elements, ref i) + Calculate(elements, ref i);
                case "-": return Calculate(elements, ref i) - Calculate(elements, ref i);
                case "*": return Calculate(elements, ref i) * Calculate(elements, ref i);
                default: return Calculate(elements, ref i) / Calculate(elements, ref i);
            }
        }
    }
}


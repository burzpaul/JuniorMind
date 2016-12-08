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
            Assert.AreEqual(8,Calculate(" "),1);  
        }
        double Calculate(string input)
        {
            string[] elements = input.Split(' ');
            int i = 0;
            return Calculate(elements, ref i);
        }
        private double Calculate(string[] elements, ref int i)
        {
            double previous = Calculate(elements, ref i);
            string currentElement = elements[i++];
            double result = 0;
            if (double.TryParse(currentElement, out result))
            {
                return result;
            }
            switch (currentElement)
            {
                case "+": return previous + Calculate(elements, ref i);
                case "-": return previous - Calculate(elements, ref i);
                case "*": return previous * Calculate(elements, ref i);
                default: return previous / Calculate(elements, ref i);
            }
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InOrderCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(6, Calculate("3 + 2 + 1"), 1);
        }
        public double Calculate(string input)
        {
            string[] elements = input.Split(' ');
            return Calculate(elements,0);
        }
        private double Calculate(string[] elements, int i)
        {
            double result = 0;
            if (i < elements.Length - 2) 
            {
                string currentElement = elements[i + 1];
                result = Convert.ToDouble(elements[i]);
                switch (currentElement)
                {
                    case "+": return result + Calculate(elements, i + 2);
                    case "-": return result - Calculate(elements, i + 2);
                    case "*": return result * Calculate(elements, i + 2);
                    default: return result / Calculate(elements, i + 2);
                }
            }
            return result;
        }
    }
}

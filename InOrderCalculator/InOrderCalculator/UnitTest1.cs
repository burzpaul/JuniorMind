using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InOrderCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(24, Calculate("8 + 9 - 1 / 2 * 3"), 1);
        }
        [TestMethod]
        public double Calculate(string input)
        {
            string[] elements = input.Split(' ');
            double result = Convert.ToDouble(elements[0]);
            return Calculate(elements,1, ref result );
        }
        private double Calculate(string[] elements, int i, ref double result)
        {
            if (i < elements.Length - 1)
            {
                double temp = Convert.ToDouble(elements[i+1]);
                switch (elements[i])
                {
                    case "+": result = result + temp;
                        break;
                    case "-": result = result - temp;
                        break;
                    case "*": result = result * temp;
                        break;
                    case "/" : result = result / temp;
                        break;
                }
                return Calculate(elements, i + 2, ref result);
            }
            return result; 
        }
    }
}

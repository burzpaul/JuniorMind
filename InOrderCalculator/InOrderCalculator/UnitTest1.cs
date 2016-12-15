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
        public void Test2()
        {
            Assert.AreEqual(7, Calculate("4 - 3 + 8 + 3 * 10 / 5 - 4 / 5 + 2"), 1);
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(7, Calculate("(1 + 2) * 2"), 1);
        }
        private double Calculate(string input)
        {
            if (input.IndexOf('(') != -1)
            {
                int lastLeft = input.LastIndexOf('(');
                int firstRight = input.IndexOf(')');
                string beforeCalculate = input.Substring(0, lastLeft);
                string afterCalculate = input.Substring(firstRight + 1, input.Length - firstRight - 1);
                return Calculate(string.Concat(beforeCalculate, Calculate(input.Substring(lastLeft + 1, firstRight - lastLeft - 1))) + afterCalculate);
            }
            string[] elements = input.Split(' ');
            double result = Convert.ToDouble(elements[0]);
            int i = 0;
            return Calculate(elements, ref i, ref result);
        }
        private double Calculate(string[] elements, ref int i, ref double result)
        {
            string currentOperation = elements[i++];
            if (i < elements.Length)
            {
                double temp = 0;
                if (double.TryParse(elements[i], out temp))
                {
                    result = GetResult(currentOperation, result, temp);
                }
                return Calculate(elements, ref i, ref result);
            }
            return result;
        }
        private static double GetResult(string operation, double result, double temp)
        {
            switch (operation)
            {
                case "+":
                    result = result + temp;
                    break;
                case "-":
                    result = result - temp;
                    break;
                case "*":
                    result = result * temp;
                    break;
                case "/":
                    result = result / temp;
                    break;
            }
            return result;
        }
    }
}
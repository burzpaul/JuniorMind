using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InOrderCalculatorV2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOnlyPlusAndMinusOperations()
        {
            Assert.AreEqual(15, Calculate("8 + 9 - 3"), 1);
        }
        [TestMethod]
        public void TestOnlyMultiplyAndDivideOperations()
        {
            Assert.AreEqual(4.8, Calculate("3 * 10 / 5 * 4 / 5"), 1);
        }
        
        [TestMethod]
        public void TestAllOperations()
        {
            Assert.AreEqual(16.2, Calculate("4 - 3 + 8 + 3 * 10 / 5 - 4 / 5 + 2"), 1);
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(6, Calculate("(1 + 2) * 2"), 1);
        }
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(15, Calculate("(1 + 2) * (2 + 3)"), 1);
        }
        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual(-74.5, Calculate("7 + (5 - (6 * 9 - 5 + 7 / 2) +10 / 5 + 6 - 7 * 5)"), 1);
                
        }
        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual(455, Calculate("(8 * (6 - 5 * 8 / 2 + 6 - 9) + 197 * 3)"), 1);
        }
        [TestMethod]
        public void RandomTest()
        {

        }
        public double Calculate(string input)
        {
            if (input.IndexOf('(') != -1)
            {
                if (input.Length > 6)
                {
                    int from = 0;
                    int to = 0;
                    DetermineParanthesisOperation(input, from, to);
                    return Calculate(input.Substring(0, from - 1) + Calculate(input.Substring(from + 1, to - 1)) + input.Substring(to + 1, input.Length - to));
                }
                return Calculate(input.Substring(1, input.Length - 1));
            }
            string[] elements = input.Split(' ');
            return Calculate(elements);
        }

        private void DetermineParanthesisOperation(string input, int from, int to)
        {
            from = input.LastIndexOf('(');
            int a = input.Length;
            string fromToFinishInput = input.Substring(from, a - from);
            to = fromToFinishInput.IndexOf(')') + from;
        }

        public double Calculate(string[] elements)
        {
            string currentOperation = MultiplicationOrDivideOpIndex(elements) > -1 ? elements[MultiplicationOrDivideOpIndex(elements)] : elements[1];

            int indexOfOperation = MultiplicationOrDivideOpIndex(elements) > -1 ? MultiplicationOrDivideOpIndex(elements) : 1;

            double firstNumberOfEcuation;
            double secondNumberOfEcuation;

            Double.TryParse(elements[indexOfOperation - 1], out firstNumberOfEcuation);
            Double.TryParse(elements[indexOfOperation + 1], out secondNumberOfEcuation);

            double result = GetResult(currentOperation, firstNumberOfEcuation, secondNumberOfEcuation);

            if (elements.Length > 3)
            {
                elements[indexOfOperation - 1] = Convert.ToString(result);

                return Calculate(ChangeArray(elements, indexOfOperation));
            }
            return result;
        }

        private string[] ChangeArray(string[] elements, int index)
        {
            for (int i = index; i < elements.Length - 2; i++)
            {
                elements[i] = elements[i + 2];
            }
            Array.Resize(ref elements, elements.Length - 2);

            return elements;
        }

        private int MultiplicationOrDivideOpIndex(string[] elements)
        {
            if (Array.IndexOf(elements, "*") != -1 || Array.IndexOf(elements, "/") != -1)
            {
                if (Array.IndexOf(elements, "*") != -1 && Array.IndexOf(elements, "/") != -1)
                {
                    return Array.IndexOf(elements, "/") < Array.IndexOf(elements, "*") ? Array.IndexOf(elements, "/") : Array.IndexOf(elements, "*");
                }
                return Array.IndexOf(elements, "*") != -1 ? Array.IndexOf(elements, "*") : Array.IndexOf(elements, "/");
            }
            return -1;
        }

        private static double GetResult(string operation, double firstNumber, double secondNumber)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }
            return result;
        }
    }
}
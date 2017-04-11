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
        public void TestForOneParanthesis()
        {
            Assert.AreEqual(3, Calculate("(1 + 2)"), 1);
        }
        [TestMethod]
        public void TestForMultipleParanthesisApart()
        {
            Assert.AreEqual(15, Calculate("(1 + 2) * (2 + 3)"), 1);
        }
        [TestMethod]
        public void TestForParanthesisAndAllOperations()
        {
            Assert.AreEqual(-67.5, Calculate("7 + (5 - (6 * 9 - 5 + 7 / 2) + 10 / 5 + 6 - 7 * 5)"), 1);
        }
        [TestMethod]
        public void RandomTest()
        {
            Assert.AreEqual(7, RezolveParantheses("(3 + 2) + 2"), 1);
        }
        [TestMethod]
        public void RandomTest2()
        {
            Assert.AreEqual("123", RezolveParantheses2("7 + (5 - (6 * 9 - 5 + 7 / 2) + 10 / 5 + 6 - 7 * 5)", 0));
        }

        public double Calculate(string input)
        {
            if (input.IndexOf('(') != -1)
            {
                return RezolveParantheses(input);
            }
            string[] elements = input.Split(' ');
            if (elements.Length == 1)
                return double.Parse(elements[0]);
            return Calculate(elements);
        }

        public double RezolveParantheses(string input)
        {
            if(input.IndexOf('(') != -1)
            {
                int from = input.LastIndexOf('(');

                string subString = input.Substring(from, input.Length - from);

                string currentEcuation = subString.Substring(0, subString.IndexOf(')') + 1);

                double result = Calculate(currentEcuation.Substring(1, currentEcuation.Length - 2));

                input = input.Replace(currentEcuation, result.ToString());

                return RezolveParantheses(input);
            }
            return Calculate(input);
        }
        public string RezolveParantheses2(string input, int index)
        {
            if (input.IndexOf('(') != -1) 
            {
                int from = input.LastIndexOf('(');

                string subString = input.Substring(from, input.Length - from);
                string currentEcuation = subString.Substring(0, subString.IndexOf(')') + 1);
                return currentEcuation.Substring(1, currentEcuation.Length - 2);
            }
            return null;
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
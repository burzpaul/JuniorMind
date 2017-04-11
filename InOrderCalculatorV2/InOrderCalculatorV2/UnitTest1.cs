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
            string[] elements = { "V3", "+", "2" };
            Assert.AreEqual(true, DoRadicalTerms(elements ,0));
        }

        public double Calculate(string input)
        {
            if (input.IndexOf('(') != -1)
            {
                return RezolveParantheses(input);
            }
            string[] elements = input.Split(' ');
            if (elements.Length == 1)
            {
                return double.Parse(elements[0]);
            }
            return Calculate(elements);
        }

        public double RezolveParantheses(string input)
        {
            if (input.IndexOf('(') != -1)
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

        public double Calculate(string[] elements)
        {
            DoRadicalTerms(elements, 0);
            if (elements.Length > 3)
            {
                int index = OrderOfOperations(elements);
                if (index != -1)
                {
                    PutResultInArray(elements, index);
                    return Calculate(RemoveFromArray(elements, index, 2));
                }
                PutResultInArray(elements, 1);
                return Calculate(RemoveFromArray(elements, 1, 2));
            }
            return GetResult(elements[1], double.Parse(elements[0]), double.Parse(elements[2]));
        }

        public bool DoRadicalTerms(string[] elements, int index)
        {
            int a = elements[index].IndexOf('V');
            if (a != -1)
            {
                elements[index].Contains("V");
                    return true;
            }
            return false;
        }

        private void PutResultInArray(string[] array, int index)
        {
            double result = GetResult(array[index], double.Parse(array[index - 1]), double.Parse(array[index + 1]));
            array[index - 1] = result.ToString();
        }

        public int OrderOfOperations(string[] elements)
        {
            int divide = Array.IndexOf(elements, "/");

            int multiply = Array.IndexOf(elements, "*");

            if (multiply != -1 && divide != -1)
            {
                return Math.Min(multiply, divide);
            }
            if (multiply != -1 || divide != -1)
            {
                return multiply != -1 ? multiply : divide;
            }
            return -1;
        }

        private string[] RemoveFromArray(string[] elements, int index, int count)
        {
            for (int i = index; i < elements.Length; i++)
            {
                if (i < elements.Length - 2)
                {
                    elements[i] = elements[i + 2];
                }
            }
            Array.Resize(ref elements, elements.Length - 2);

            return elements;
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
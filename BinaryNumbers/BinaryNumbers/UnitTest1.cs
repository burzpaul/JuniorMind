using System;
using System.Linq;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryNumbers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GiveDecimalNumber()
        {
            byte[] a = new byte[] { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(a, TransformToBinary(49));
        }
        [TestMethod]
        public void NotOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(206), ImplementNotOperator(TransformToBinary(49)));
        }
        [TestMethod]
        public void OrOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(7), ImplementOperator(TransformToBinary(5), TransformToBinary(3),"OR"));
        }
        [TestMethod]
        public void AndOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(1), ImplementOperator(TransformToBinary(5), TransformToBinary(3),"AND"));
        }
        [TestMethod]
        public void XOROperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(6), ImplementOperator(TransformToBinary(5), TransformToBinary(3), "XOR"));
        }
        [TestMethod]
        public void LeftShift()
        {

            CollectionAssert.AreEqual(TransformToBinary(20), ImplementLeftHandShift(TransformToBinary(5), 2));
        }
        [TestMethod]
        public void RightShift()
        {
            CollectionAssert.AreEqual(TransformToBinary(12), ImplementRightHandShift(TransformToBinary(50), 2));
        }
        private byte[] TransformToBinary(int number)
        {
            int index = 0;
            byte[] array = new byte[GetTheIndex(number)];

            while (number > 0)
            {
                array[index] = (byte)(number % 2);
                number = number / 2;
                index++;
            }
            Array.Reverse(array);
            return array;
        }
        private int GetTheIndex(int theNumber)
        {
            int m = 0;
            while (theNumber > 0)
            {
                theNumber = theNumber / 2;
                m++;
            }
            if (m >= 4)
                return m;
            else
                return 4;
        }
        private byte[] ImplementNotOperator(byte[] array)
        {
            int var = 0;
            int index = ((array.Length >= 8) ? array.Length : 8);
            byte[] newArray = new byte[index];

            Array.Reverse(array);

            Array.Copy(array, newArray, array.Length);

            foreach (byte a in newArray)
            {
                newArray[var] = (byte)((a==1)? 0 : 1);
                var++;
            }
            Array.Reverse(newArray);
            return newArray;
        }
        private byte[] ImplementOperator(byte[] firstArray, byte[] secondArray, string Case)
        {
            byte[] resultArray = new byte[firstArray.Length];
            for (int i = 0; i < resultArray.Length; i++)
            {
                switch (Case)
                {

                    case "OR":
                        resultArray[i] = (byte)((firstArray[i] == 0 && secondArray[i] == 0) ? 0 : 1);
                        break;

                    case "AND":
                        resultArray[i] = (byte)((firstArray[i] == 1 && secondArray[i] == 1) ? 1 : 0);
                        break;
                    case "XOR":
                        resultArray[i] = (byte)((firstArray[i] == 0 && secondArray[i] == 1 || firstArray[i] == 1 && secondArray[i] == 0) ? 1 : 0);
                        break;
                }
            }
            return resultArray;
        }
        private byte[] ImplementLeftHandShift(byte[] array, int numberOfPositions)
        {
            int var = 0;
            int index = ((array.Length >= 8) ? array.Length : 8);
            byte[] newArray = new byte[index];

            Array.Copy(array, newArray, array.Length);

            int found = Array.IndexOf(newArray, (byte)1);

            byte[] resultArray = new byte[newArray.Length-numberOfPositions-1];

            while(var < resultArray.Length)
            {
                resultArray[var] = newArray[found];
                found++;
                var++;
            }
            return resultArray;
        }
        private byte[] ImplementRightHandShift(byte[] array, int numberOfPositions)
        {

        }

    }
}
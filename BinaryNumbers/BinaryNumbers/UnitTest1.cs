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
        public void ShiftLeft()
        {
            byte[] a = new byte[] { 0, 1, 0, 1, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(a, ImplementLeftHandShift(TransformToBinary(5), 4));
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
            int index = 0, var = 0;

            if (array.Length >= 8)
            {
                index = array.Length;
            }
            else
            {
                index = 8;
            }
            byte[] newArray = new byte[index];

            Array.Reverse(array);

            Array.Copy(array, newArray, array.Length);

            foreach (byte a in newArray)
            {
                if (a == 1)
                    newArray[var] = 0;
                else
                    newArray[var] = 1;
                var++;
            }
            Array.Reverse(newArray);
            return newArray;
        }
        byte[] ImplementOperator(byte[] firstArray, byte[] secondArray, string Case)
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
                }
            }
            return resultArray;
        }
        private byte[] ImplementLeftHandShift(byte[] array, int numberOfPositions)
        {
            int index = 0;
            byte[] newArray = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            while (numberOfPositions < array.Length)
            {
                newArray[index] = array[numberOfPositions];
                index++;
                numberOfPositions++;
            }
            return newArray;
        }
    }
}
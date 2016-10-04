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
            byte[] a = new byte[] { 0, 0, 1, 1, 0, 0, 0, 1 };
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
            CollectionAssert.AreEqual(TransformToBinary(7), ImplementOrOperator(TransformToBinary(5), TransformToBinary(3)));
        }
        [TestMethod]
        public void AndOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(1), ImplementAndOperator(TransformToBinary(5), TransformToBinary(3)));
        }
        [TestMethod]
        public void X0ROperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(6), ImplementXOROperator(TransformToBinary(5),TransformToBinary(3)));
        }
        [TestMethod]
        public void ShiftLeft()
        {
            CollectionAssert.AreEqual(TransformToBinary(20), ImplementLeftHandShift(TransformToBinary(5), 2));
        }
        [TestMethod]
        public void ShiftRight()
        {
            CollectionAssert.AreEqual(TransformToBinary(12), ImplementRightHandShift(TransformToBinary(50),2));
        }
        private byte[] TransformToBinary(int number)
        {
            byte[] array = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            int index = 0;
            while(number>0)
            {
                array[index] = (byte)(number % 2);
                number = number / 2;
                index++;
            }
            Array.Reverse(array);
            return array;
        }
        private byte[] ImplementNotOperator(byte[] byteArray)
        {
            int index = 0;
            foreach (byte a in byteArray)
            { if (a == 1)
                    byteArray[index] = 0;
                else
                    byteArray[index] = 1;
                index++;
            }
            return byteArray;
        }
        private byte[] ImplementOrOperator(byte[] firstArray, byte[] secondArray)
        {
            byte[] thirdArray = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            int index = 0;
            foreach(byte a in thirdArray)
            {
                if (firstArray[index] == 0 && secondArray[index] == 0)
                    thirdArray[index] = 0;
                else
                    thirdArray[index] = 1;
                index++;
            }
            return thirdArray;
        }
        private byte[] ImplementAndOperator(byte[] firstArray, byte[] secondArray)
        {
            byte[] thirdArray = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            int index = 0;
            foreach (byte a in thirdArray)
            {
                if (firstArray[index] == 1 && secondArray[index] == 1)
                    thirdArray[index] = 1;
                else
                    thirdArray[index] = 0;
                index++;
            }
            return thirdArray;
        }
        private byte[] ImplementXOROperator(byte[] firstArray, byte[] secondArray)
        {
            byte[] thirdArray = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            int index = 0;
            foreach (byte a in thirdArray)
            {
                if (firstArray[index] == 0 && secondArray[index] == 1 || firstArray[index] == 1 && secondArray[index] == 0)
                    thirdArray[index] = 1;
                else
                    thirdArray[index] = 0;
                index++;
            }
            return thirdArray;
        }
        private byte[] ImplementLeftHandShift(byte[] array, int numberOfPositions)
        {
            int index = 0;
            byte[] newArray = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            while (numberOfPositions<array.Length)
            {
                newArray[index] = array[numberOfPositions];
                index++;
                numberOfPositions++;
            }
            return newArray;
        }
        private byte[] ImplementRightHandShift(byte[] array, int numberOfPositions)
        {
            
            byte[] newArray = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            int index = 0;
            while (index+numberOfPositions < array.Length)
            {
                newArray[index+numberOfPositions] = array[index];
                index++;
            }
            return newArray;
        }
    }
}

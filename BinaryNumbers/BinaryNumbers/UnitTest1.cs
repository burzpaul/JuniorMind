using System;
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
        public byte[] TransformToBinary(int number)
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
        public byte[] ImplementNotOperator(byte[] firstArray)
        {
            return null;
        }
    }
}

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
            byte[] a = new byte[] { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(a, TransformToBinary(49));
        }
        public byte[] TransformToBinary(int number)
        {
            byte[] array = new byte[] {  };
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
    }
}

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
        public void BinaryConversion()
        {
            byte[] array = new byte[] { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(array, TransformToBinary(49));
        }
        [TestMethod]
        public void NotOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(211), ImplementNotOperator(TransformToBinary(300)));
        }
        public byte[] TransformToBinary(int number)
        {
            byte[] resultArray = new byte[0];

            while (number > 0)
            {
                Array.Resize(ref resultArray, resultArray.Length + 1);
                resultArray[resultArray.Length - 1] = (byte)(number % 2);
                number = number / 2;
            }

            Array.Reverse(resultArray);

            return resultArray;
        }
        public byte[] ImplementNotOperator(byte[] byteArray)
        {
            int position = 0;

            if (byteArray.Length < 8)
            {
                Array.Reverse(byteArray);
                Array.Resize(ref byteArray, byteArray.Length + (8 - byteArray.Length));
                Array.Reverse(byteArray);
            }
            foreach(byte b in byteArray)
            {
                byteArray[position]=(byte)((b == 0) ? 1 : 0);
                position++;
            }

            int firstOne = Array.IndexOf(byteArray, (byte)(1));
            Array.Reverse(byteArray);
            Array.Resize(ref byteArray, (byteArray.Length - firstOne));
            Array.Reverse(byteArray);

            return byteArray;
        }
    }
}
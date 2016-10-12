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
        [TestMethod]
        public void OrOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(7), ImplementOperator(TransformToBinary(5), TransformToBinary(3), "OR"));
        }
        [TestMethod]
        public void AndOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(1), ImplementOperator(TransformToBinary(5), TransformToBinary(3), "AND"));
        }
        [TestMethod]
        public void XoROperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(6), ImplementOperator(TransformToBinary(5), TransformToBinary(3), "XOR"));
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
            foreach (byte b in byteArray)
            {
                byteArray[position] = (byte)((b == 0) ? 1 : 0);
                position++;
            }
            return TrimArray(byteArray);
        }
        public byte[] ImplementOperator(byte[] firstArray, byte[] secondArray, string Case)
        {
            if (firstArray.Length > secondArray.Length)
            {
                Array.Reverse(secondArray);
                Array.Resize(ref secondArray, (secondArray.Length + (firstArray.Length - secondArray.Length)));
                Array.Reverse(secondArray);
            }
            else
            {
                Array.Reverse(firstArray);
                Array.Resize(ref firstArray, (firstArray.Length + (secondArray.Length - firstArray.Length)));
                Array.Reverse(firstArray);
            }

            byte[] resultArray = new byte[firstArray.Length];
            for (int i = 0; i < firstArray.Length; i++)
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

            return TrimArray(resultArray); ;
        }
        public byte[] TrimArray(byte[] byteArray)
        {
            int firstOne = Array.IndexOf(byteArray, (byte)(1));
            Array.Reverse(byteArray);
            Array.Resize(ref byteArray, (byteArray.Length - firstOne));
            Array.Reverse(byteArray);
            return byteArray;
        }
    }
}

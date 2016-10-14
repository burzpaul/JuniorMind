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
            CollectionAssert.AreEqual(TransformToBinary(206), NotOperator(TransformToBinary(49)));
        }
        [TestMethod]
        public void OrOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(7), OperatorOperations(TransformToBinary(5), TransformToBinary(3), "OR"));
        }
        [TestMethod]
        public void AndOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(1), OperatorOperations(TransformToBinary(5), TransformToBinary(3), "AND"));
        }
        [TestMethod]
        public void XoROperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(6), OperatorOperations(TransformToBinary(5), TransformToBinary(3), "XOR"));
        }
        [TestMethod]
        public void RightShift()
        {
            CollectionAssert.AreEqual(TransformToBinary(12), RightShift(TransformToBinary(50), 2));
        }
        [TestMethod]
        public void LeftShift()
        {
            CollectionAssert.AreEqual(TransformToBinary(8), LeftShift(TransformToBinary(1), 3));
        }
        [TestMethod]
        public void LessThan()
        {
           Assert.AreEqual(true, LessThan(TransformToBinary(3),TransformToBinary(3)));
        }
        [TestMethod]
        public void GreaterThen()
        {
            Assert.AreEqual(false, GreaterThan(TransformToBinary(4), TransformToBinary(4)));
        }
        [TestMethod]
        public void Equal()
        {
            Assert.AreEqual(true, Equal(TransformToBinary(3), TransformToBinary(3)));
        }
        [TestMethod]
        public void NotEqual()
        {
            Assert.AreEqual(true, NotEqual(TransformToBinary(4), TransformToBinary(3)));
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
        public byte[] NotOperator(byte[] byteArray)
        {
            if (byteArray.Length < 8)
            {
                Array.Reverse(byteArray);
                Array.Resize(ref byteArray, byteArray.Length + (8 - byteArray.Length));
                Array.Reverse(byteArray);
            }
            for(int i=0; i < byteArray.Length; i++)
            {
                byteArray[i] = (byte)((byteArray[i] == 0) ? 1 : 0);
            }
            return TrimArray(byteArray);
        }
        public byte[] OperatorOperations(byte[] firstArray, byte[] secondArray, string selectedOperation)
        {
            byte[] resultArray = new byte[((firstArray.Length > secondArray.Length) ? firstArray.Length : secondArray.Length)];
            for (int i = resultArray.Length-1; i>=0 ; i--)
                switch (selectedOperation)
                {

                    case "OR":
                        resultArray[resultArray.Length - 1 -i] = (byte)(((GetIndex(firstArray,i) == 0 && (GetIndex(secondArray, i) == 0) ? 0 : 1)));
                        break;
                    case "AND":
                        resultArray[resultArray.Length - 1 - i] = (byte)(((GetIndex(firstArray, i) == 1 && (GetIndex(secondArray, i) == 1) ? 1 : 0)));
                        break;
                    case "XOR":
                        resultArray[resultArray.Length - 1 - i] = (byte)((GetIndex(firstArray, i) == 0 && GetIndex(secondArray, i) == 1 || GetIndex(firstArray, i) == 1 && GetIndex(secondArray, i) == 0) ? 1 : 0);
                        break;
                }

            return TrimArray(resultArray); ;
        }
        public byte[] LeftShift(byte[] byteArray, int numberOfShitfs)
        {
            byte[] resultArray = new byte[byteArray.Length + numberOfShitfs];
            for (int i = 0; i < byteArray.Length; i++)
            {
                resultArray[i] = byteArray[i];
            }
            return resultArray;
        }
        public byte[] RightShift(byte[] byteArray, int numberOfShitfs)
        {
            Array.Resize(ref byteArray, byteArray.Length - numberOfShitfs);
            return byteArray;
        }
        bool LessThan(byte[] firstArray, byte[] secondArray)
        {
            for (int i = ((firstArray.Length > secondArray.Length) ? firstArray.Length : secondArray.Length) - 1; i >= 0; i++) 
            {
                if (GetIndex(firstArray, i) != GetIndex(secondArray, i))
                    return GetIndex(firstArray, i) < GetIndex(secondArray, i);          
            }
            return true;
        }
        bool GreaterThan(byte[] firstArray, byte[] secondArray)
        {
            return !LessThan(firstArray, secondArray);
        }
        bool Equal(byte[] firstArray, byte[] secondArray)
        {
            return ((!GreaterThan(firstArray, secondArray)) && LessThan(firstArray, secondArray));
        }
        bool NotEqual(byte[] firstArray,byte[] secondArray)
        {
            return !Equal(firstArray, secondArray);
        }
        public byte[] TrimArray(byte[] byteArray)
        {
            int firstOne = Array.IndexOf(byteArray, (byte)(1));
         
                Array.Reverse(byteArray);
                Array.Resize(ref byteArray, byteArray.Length - firstOne);
                Array.Reverse(byteArray);
         
            return byteArray;
        }
        public byte GetIndex(byte[] Arr, int k)
        {
            if (k >= Arr.Length)
                return 0;
            return Arr[Arr.Length - 1 - k];
    
        }
    }
}

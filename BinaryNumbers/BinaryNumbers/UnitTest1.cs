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
        public void ConvertToAnyBase()
        {
            byte[] array = new byte[] { 4,6,7,2 };
            CollectionAssert.AreEqual(array, ConvertToAnyBase(2490, 8));
        }
        [TestMethod]
        public void BinaryConversion()
        {
            byte[] array = new byte[] { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(array, TransformToBinary(49));
        }
        [TestMethod]
        public void NotOperator()
        {
            CollectionAssert.AreEqual(TransformToBinary(14), NotOperator(TransformToBinary(49)));
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
           Assert.AreEqual(true, LessThan(TransformToBinary(3),TransformToBinary(4)));
        }
        [TestMethod]
        public void LessThanAnyBase()
        {
            Assert.AreEqual(true, LessThan(ConvertToAnyBase(2490, 8), ConvertToAnyBase(2491,8)));
        }
        [TestMethod]
        public void GreaterThen()
        {
            Assert.AreEqual(false, GreaterThan(TransformToBinary(3), TransformToBinary(4)));
        }
        [TestMethod]
        public void GreaterThenAnyBase()
        {
            Assert.AreEqual(false, GreaterThan(ConvertToAnyBase(2490, 8), ConvertToAnyBase(2491, 8)));
        }
        [TestMethod]
        public void Equal()
        {
            Assert.AreEqual(true, Equal(TransformToBinary(3), TransformToBinary(3)));
        }
        [TestMethod]
        public void EqualAnyBase()
        {
            Assert.AreEqual(true, Equal(ConvertToAnyBase(255, 255), ConvertToAnyBase(255, 255)));
        }
        [TestMethod]
        public void NotEqual()
        {
            Assert.AreEqual(true, NotEqual(TransformToBinary(4), TransformToBinary(3)));
        }
        [TestMethod]
        public void NotEqualAnyBase()
        {
            Assert.AreEqual(true, NotEqual(ConvertToAnyBase(255, 128), ConvertToAnyBase(255, 255)));
        }
        [TestMethod]
        public void Add()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(142,5), Add(ConvertToAnyBase(127,5), ConvertToAnyBase(15,5),5));
        }
        [TestMethod]
        public void Minus()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(29,16), Minus(ConvertToAnyBase(142,16), ConvertToAnyBase(113,16),16));
        }
        [TestMethod]
        public void Multiply()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(49,16), Multiply(ConvertToAnyBase(7,16), ConvertToAnyBase(7,16),16));
        }
        [TestMethod]
        public void Divide()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(6,6), Divide(ConvertToAnyBase(36,6), ConvertToAnyBase(6,6),6));
        }
        [TestMethod]
        public void Factorial()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(49,16), Divide(Factorial(ConvertToAnyBase(49,16),16), Factorial(ConvertToAnyBase(48,16),16),16));
        }
        public byte[] Factorial(byte[] Array,byte givenBase)
        {
            byte[] factorialArray = new byte[]{1};
            var i = new byte[] { 1 };
            for (i =new byte[] { 1 }; Equal(i, Array); i = Add(i, new byte[] { 1 }, givenBase)) 
            { factorialArray = Multiply(factorialArray, i, givenBase); }
            return factorialArray;
        }
        public byte[] ConvertToAnyBase(int number, int theBase)
        {
            byte[] resultArray = new byte[0];

            while (number > 0)
            {
                Array.Resize(ref resultArray, resultArray.Length + 1);
                resultArray[resultArray.Length - 1] = (byte)(number % theBase);
                number = number / theBase;
            }

            Array.Reverse(resultArray);

            return resultArray;
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
            for(int i=0; i < byteArray.Length; i++)
            {
                byteArray[i] = (byte)((byteArray[i] == 0) ? 1 : 0);
            }
            return TrimArray(byteArray);
        }
        public byte[] OperatorOperations(byte[] firstArray, byte[] secondArray, string selectedOperation)
        {
            byte[] resultArray = new byte[Math.Max(firstArray.Length, secondArray.Length)];
            for (int i = resultArray.Length-1; i>=0 ; i--)
                switch (selectedOperation)
                {
                    case "OR":
                        resultArray[resultArray.Length - 1 - i] = (byte)(Compare(GetIndex(firstArray, i),GetIndex(secondArray, i), 0) ? 0 : 1);
                        break;
                    case "AND":
                        resultArray[resultArray.Length - 1 - i] = (byte)(Compare(GetIndex(firstArray, i),GetIndex(secondArray, i), 1) ? 1 : 0);
                        break;
                    case "XOR":
                        resultArray[resultArray.Length - 1 - i] = (byte)(!Compare(GetIndex(firstArray, i), GetIndex(secondArray, i), 0) && !Compare(GetIndex(firstArray, i), GetIndex(secondArray, i), 1) ? 1 : 0);
                        break;
                }
            return TrimArray(resultArray); ;
        }
        public byte[] LeftShift(byte[] byteArray, int numberOfShitfs)
        {
            Array.Resize(ref byteArray, byteArray.Length + numberOfShitfs);
           
            return byteArray;
        }
        public byte[] RightShift(byte[] byteArray, int numberOfShitfs)
        {
            Array.Resize(ref byteArray, byteArray.Length - numberOfShitfs);
            return byteArray;
        }
        public byte[] Add(byte[] firstArray, byte[] secondArray,byte givenBase)
        {
            byte[] resultArray = new byte[Math.Max(firstArray.Length, secondArray.Length)];
            int carry = 0;
            for (int i = 0; i < resultArray.Length; i++)
            {
                var sum = CalculateSum(GetIndex(firstArray, i), GetIndex(secondArray, i), carry);
                resultArray[i] = (byte)(sum % givenBase);
                carry = (sum > (givenBase - 1)) ? 1 : 0;
            }
            if (carry == 1)
            {
                Array.Resize(ref resultArray, resultArray.Length + 1);
                resultArray[resultArray.Length - 1] = (byte)(carry);
            }
            Array.Reverse(resultArray);
            return resultArray;
        }
        public byte[] Minus(byte[] firstArray, byte[] secondArray,byte givenBase)
        {
            byte[] resultArray = new byte[Math.Max(firstArray.Length, secondArray.Length)];
            int carry = 0;
            for (int i = 0; i < resultArray.Length; i++)
            {
                var sum = givenBase + CalculateSum(GetIndex(firstArray, i), -GetIndex(secondArray, i), -carry);
                resultArray[resultArray.Length - i - 1] = (byte)(sum % givenBase);
                carry = (sum < givenBase) ? 1 : 0;
            }
            return TrimArray(resultArray);
        }
        public byte[] Multiply(byte[] firstArray, byte[] secondArray,byte givenBase)
        {
            byte[] resultArray = new byte[1];
            for (var i = new byte[] { 1 }; LessThan(i,secondArray); i = Add(i, new byte[] { 1 },givenBase))        
                resultArray = Add(resultArray, firstArray,givenBase);         
            return resultArray;
        }
        public byte[] Divide(byte[] firstArray, byte[] secondArray,byte givenBase)
        {
            byte[] resultArray = new byte[1];
            for (var i = secondArray  ; LessThan(i,firstArray); i = Add(i, secondArray,givenBase))
                resultArray = Add(resultArray, new byte[] { 1 },givenBase);
            return resultArray;
        }
        bool LessThan(byte[] firstArray, byte[] secondArray)
        {
            for (int i = (Math.Max(firstArray.Length, secondArray.Length) - 1); i >= 0; i--)
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
        bool Compare(byte firstBite,byte secondBite, byte bite)
        {
            if (firstBite == bite && secondBite == bite)
                return true;
            return false;
        }
        public byte[] TrimArray(byte[] byteArray)
        {
            int firstOne = Array.IndexOf(byteArray, (byte)(1));
         
                Array.Reverse(byteArray);
                Array.Resize(ref byteArray, byteArray.Length - firstOne);
                Array.Reverse(byteArray);
         
            return byteArray;
        }
        public byte GetIndex(byte[] ByteArray, int index)
        {
            if (index >= ByteArray.Length)
                return 0;
            return ByteArray[ByteArray.Length - 1 - index];
    
        }
        public int CalculateSum(int firstArrayBite, int secondArrayBite, int theCarry)
        {
            return firstArrayBite + secondArrayBite + theCarry;
        }
       
    }
}
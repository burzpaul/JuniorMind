using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryNumbers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GiveDecimalNumber()
        {
            byte[] b = new byte[] { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(b, BinaryNumbers(49));
        }
        public byte[] BinaryNumbers(int number)
        {
            int index = GetTheIndex(number);

            byte[] bytes = new byte[index];

            BinaryConversion(bytes, index-1, number);
            
                    return bytes;
           
        }
        public int GetTheIndex(int theNumber)
        {
            int m = 0;
            while(theNumber>0)
            {
                theNumber = theNumber / 2;
                m++;
            }
            return m;
        }
       void BinaryConversion(byte[] array,int theIndex,int theNumber)
        {
            while(theIndex>=0)
            {
                array[theIndex] = (byte)(theNumber % 2);
                theNumber = theNumber / 2;
                theIndex--;
            }
        }       

    }
}

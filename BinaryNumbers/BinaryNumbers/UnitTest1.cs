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
            Assert.AreEqual("110001", BinaryNumbers(49));
        }
        public string BinaryNumbers(int number)
        {
            int index = GetTheIndex(number);
            byte[] bytes = new byte[index];
            BinaryConversion(bytes, index-1, number);
            string response = string.Empty;

            foreach (byte b in bytes)
                response += (int)b;

                    return response;
           
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

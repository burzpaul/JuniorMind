using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loto
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForSotedLotoNumbers()
        {
            int[] sorted = new int[] { 1, 3, 57, 65, 79, 98, 123 };
            CollectionAssert.AreEqual(sorted, SortLotoNumbers(new int[] { 65, 1, 123, 3, 57, 98, 79 }));
        }
        public int[] SortLotoNumbers(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length - 1; i++) 
            {
                for (int j = i + 1; j < numbersArray.Length; j++) 
                {
                    if (numbersArray[j - 1] > numbersArray[j])
                    {
                        Swap(ref numbersArray[j - 1], ref numbersArray[j]);
                    }
                }
            }
            return numbersArray;
        }
        void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}

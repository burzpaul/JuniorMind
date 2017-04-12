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
                int j = i + 1;
                while (j > 0)
                {
                    if (numbersArray[j - 1] > numbersArray[j])
                    {
                        int temp = numbersArray[j - 1];
                        numbersArray[j - 1] = numbersArray[j];
                        numbersArray[j] = temp;
                    }
                    j--;
                }
            }
            return numbersArray;
        }
    }
}

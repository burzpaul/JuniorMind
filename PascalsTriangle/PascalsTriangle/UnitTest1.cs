using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PascalsTriangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            CollectionAssert.AreEqual(new int[] { 1, 1}, GenereteRowOfPascalsTriangle(2));     
        }
        [TestMethod]
        public void Test2()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 1 }, GenereteRowOfPascalsTriangle(3));
        }
        [TestMethod]
        public void Test3()
        {
            CollectionAssert.AreEqual(new int[] { 1, 14, 91, 364, 1001, 2002, 3003, 3432, 3003, 2002, 1001, 364, 91, 14, 1 }, GenereteRowOfPascalsTriangle(15));
        }
        private int[] GenereteRowOfPascalsTriangle(int row)
        {
            int[] result = new int[row];
            result[0] = 1;
            result[result.Length - 1] = 1;
            if (row < 3) return result;
            int[] previousRow = GenereteRowOfPascalsTriangle(row - 1);
            for (int i = 1; i < row - 1; i++)
                result[i] = previousRow[i - 1] + previousRow[i];
            return result;
        }
    }
}

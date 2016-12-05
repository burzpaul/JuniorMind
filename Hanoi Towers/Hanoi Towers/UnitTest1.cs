using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hanoi_Towers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(new int[] { 5, 4, 3, 2, 1 },HanoiTowers(5, new int[] { 5, 4, 3, 2, 1 },new int[63],new int[63]));
        }
        public int[] HanoiTowers(int disks, int[] A, int[] B, int[] C)
        {
            return A;
        }
    }
}

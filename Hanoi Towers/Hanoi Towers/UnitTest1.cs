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
            CollectionAssert.AreEqual(new int[] { 5, 4, 3, 2, 1 }, HanoiTowers(5, new int[] { 5, 4, 3, 2, 1 }, new int[5], new int[5]));
        }
        public int[] HanoiTowers(int disks, int[] A, int[] B, int[] C)
        {
            if (disks == 1) 
            {
                return  MoveDisks(disks, A, C);
            }
            else
            {
                HanoiTowers(disks - 1, A, B, C);
                MoveDisks(disks, A, C);
                HanoiTowers(disks - 1, B, C, A);
            }
            return C;
        }
        int[] MoveDisks(int numberOfDisks, int[] fromTower, int[] toTower)
        {
            toTower[numberOfDisks - 1] = fromTower[numberOfDisks - 1];
            Array.Resize(ref fromTower, fromTower.Length - 1);
            return fromTower;
        }
    }
}

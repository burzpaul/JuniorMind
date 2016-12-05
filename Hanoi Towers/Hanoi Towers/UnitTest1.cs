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
            int n = 5;
            CollectionAssert.AreEqual(GenerateNumberOfDisks(n), HanoiTowers(n, GenerateNumberOfDisks(n), new int[n], new int[n]));
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
        public int[] MoveDisks(int numberOfDisks, int[] fromTower, int[] toTower)
        {
            toTower[numberOfDisks - 1] = fromTower[numberOfDisks - 1];
            Array.Resize(ref fromTower, fromTower.Length - 1);
            return fromTower;
        }
        public int[] GenerateNumberOfDisks(int number)
        {
            int[] generated = new int[number];
            int j = 0;
            for (int i = number; i >= 1; i--) 
            {
                generated[j] = i;
                j++;
            }
            return generated;
        }
    }
}

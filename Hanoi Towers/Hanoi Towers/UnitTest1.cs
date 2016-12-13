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
            Assert.AreEqual("AC AB CB AC BA BC AC", HanoiTowers(3, 'A', 'B', 'C'));
        }
        public string HanoiTowers(int disks, char from, char temporary, char to )
        {
            string moves = string.Empty;
            if (disks == 1) 
                return Convert.ToString(from) + Convert.ToString(to);
            moves = moves + HanoiTowers(disks - 1, from, to, temporary);
            moves = moves + " " + HanoiTowers(1, from, temporary, to);
            return moves = moves + " " + HanoiTowers(disks - 1, temporary  , from, to);                 
        }
    }
}

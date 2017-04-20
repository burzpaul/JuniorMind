using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizationOfElections
{
    [TestClass]
    public class Elections
    {
        [TestMethod]
        public void Test_If_All_The_Candidates_Are_Centralized()
        {
            var sectia1Candidati = new string[] { "Ioan Cristina", "Adrian Wiener", "Ion Popa", "Viorel Ilie", "Ioan Simionca" };

            var sectia2Candidati = new string[] { "Allen Coliban", "Ion Vela", "Alina Gorghiu", "Doina Silistru", "Romulus Bulacu" };

            var expected = new string[] { "Ioan Cristina", "Adrian Wiener", "Ion Popa", "Viorel Ilie","Ioan Simionca",
                                                "Allen Coliban", "Ion Vela", "Alina Gorghiu", "Doina Silistru", "Romulus Bulacu" };

            CollectionAssert.AreEqual();
        }
        [TestMethod]
        public void Test_If_All_Votes_Are_Centralized()
        {
            var sectia1Voturi = new int[] { 31, 30, 29, 28, 27 };

            var sectia2Voturi = new int[] { 16, 15, 14, 13, 12 };

            var expected = new int[] { 47, 45, 43, 41, 39 };

            CollectionAssert.AreEqual();

        }
        [TestMethod]
        public void Test_Votes_And_Candidates_Are_Centralized()
        {

        }
    }
}

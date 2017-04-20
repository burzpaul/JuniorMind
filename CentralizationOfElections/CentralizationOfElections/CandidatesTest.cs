using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizationOfElections
{
    [TestClass]
    public class CandidatesTest
    {
        [TestMethod]
        public void TestIsSameCandidate()
        {
            var candidate = new Candidate("Paul", 31);

            Assert.AreEqual(true, candidate.IsSameCandidate("Paul"));
        }
        [TestMethod]
        public void TestIsSameCandidate2()
        {
            var candidate = new Candidate("Paul", 31);

            var candidate2 = new Candidate("Paul", 31);

            Assert.AreEqual(true, candidate.IsSameCandidate(candidate2));
        }
        [TestMethod]
        public void TestFirstHasMoreVotes()
        {
            var candidate = new Candidate("Paul", 32);

            var candidate2 = new Candidate("Raul", 31);

            Assert.AreEqual(true, candidate.HasMoreVotes(candidate2));
        }
        [TestMethod]
        public void TestHasLessVotes()
        {
            var candidate = new Candidate("Paul", 32);

            var candidate2 = new Candidate("Raul", 31);

            Assert.AreEqual(false, candidate2.HasMoreVotes(candidate));
        }
    }
}

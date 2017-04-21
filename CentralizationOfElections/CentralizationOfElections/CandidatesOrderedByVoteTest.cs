using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizationOfElections
{
    [TestClass]
    public class CandidatesOrderedByVoteTest
    {
        [TestMethod]
        public void Test_If_Sorted_By_Number_Of_Votes()
        {
            var candidates = new Candidate[] { new Candidate("D", 13), new Candidate("E", 121), new Candidate("B", 92),
                                                            new Candidate("A", 61), new Candidate("C", 41) };

            var expected = new Candidate[] { candidates[1] };

            new CandidatesOrderedByVotes(candidates);

            Assert.AreEqual(true,expected[0].IsSameCandidate((candidates)[0]));
        }
    }
}

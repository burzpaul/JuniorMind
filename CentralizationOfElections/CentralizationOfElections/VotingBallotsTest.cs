using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizationOfElections
{
    [TestClass]
    public class VotingBallotsTest
    {
        [TestMethod]
        public void Test_If_Added_Ballots()
        {
            var state1 = new Candidate[] { new Candidate("A", 31), new Candidate("B", 30), new Candidate("C", 29),
                                                     new Candidate("D", 28), new Candidate("E", 27) };


            var state2 = new Candidate[] { new Candidate("A", 16), new Candidate("B", 15), new Candidate("C", 14),
                                                     new Candidate("D", 13), new Candidate("E", 12) };

            var votingBallots = new VotingBalot[] { new VotingBalot("state1", state1), new VotingBalot("state2", state2) };

            Assert.AreEqual(false,votingBallots[0].Equals(votingBallots[1]));
        }
        [TestMethod]
        public void Test_If_New_Ballot_Added()
        {
            var state1 = new Candidate[] { new Candidate("A", 31), new Candidate("B", 30), new Candidate("C", 29),
                                                     new Candidate("D", 28), new Candidate("E", 27) };


            var state2 = new Candidate[] { new Candidate("A", 6), new Candidate("B", 9), new Candidate("C", 4),
                                                     new Candidate("D", 13), new Candidate("E", 12) };

            var votingBallot = new VotingBalot[] { new VotingBalot("state1", state1) };

            var votingBallot2 = new VotingBalot("state2", state2);

            votingBallot[0].AddCandidatesAndAddTheirVotesFromBallots(votingBallot2);

            Assert.AreEqual(true, votingBallot[0].ReturnCandidatesArray()[0].IsSameCandidate("A"));

        }
    }
}

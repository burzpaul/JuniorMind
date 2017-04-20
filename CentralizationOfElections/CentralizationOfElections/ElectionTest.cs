using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizationOfElections
{
    [TestClass]
    public class ElectionTest
    {
        [TestMethod]
        public void Test_All_Candidates_Are_In_Same_Voting_Order ()
        {
            var state1 = new Candidate[] { new Candidate("A", 31), new Candidate("B", 30), new Candidate("C", 29),
                                                     new Candidate("D", 28), new Candidate("E", 27) };
            

            var state2 =  new Candidate[] { new Candidate("A", 16), new Candidate("B", 15), new Candidate("C", 14),
                                                     new Candidate("D", 13), new Candidate("E", 12) };

            var votingBallots = new VotingBalot[] { new VotingBalot("state1", state1), new VotingBalot("state2", state2) };


            var expected = new Candidate[] { new Candidate("A", 47), new Candidate("B", 45), new Candidate("C", 43),
                                             new Candidate("D", 41), new Candidate("E", 39) };

            var election = new Election().CentralizeVotes(votingBallots);

            Assert.AreEqual(true,expected[0].IsSameCandidate(election[0]));
        }
        [TestMethod]
        public void Test_Correct_Election_Reusl()
        {
            var state1 = new Candidate[] { new Candidate("A", 31), new Candidate("B", 30), new Candidate("C", 29),
                                                     new Candidate("D", 28), new Candidate("E", 27) };


            var state2 = new Candidate[] { new Candidate("A", 6), new Candidate("B", 9), new Candidate("C", 4),
                                                     new Candidate("D", 13), new Candidate("E", 12) };

            var votingBallots = new VotingBalot[] { new VotingBalot("state1", state1), new VotingBalot("state2", state2) };


            var expected = new Candidate[] { new Candidate("D", 41), new Candidate("B", 39), new Candidate("E", 39),
                                        new Candidate("A", 37), new Candidate("B", 39), new Candidate("C", 33) };

            var election = new Election().CentralizeVotes(votingBallots);

            Assert.AreEqual(true, expected[0].IsSameCandidate(election[0]));
        }
    }
}

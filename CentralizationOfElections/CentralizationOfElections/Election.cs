using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizationOfElections
{
    [TestClass]
    public class Election
    {
        [TestMethod]
        public void Test_All_Candidates_Are_In_Same_Voting_Order ()
        {
            var state1Voting = new Candidate[] { new Candidate("A", 31), new Candidate("B", 30), new Candidate("C", 29),
                                                     new Candidate("D", 28), new Candidate("E", 27) };
            

            var state2Voting =  new Candidate[] { new Candidate("A", 16), new Candidate("B", 15), new Candidate("C", 14),
                                                     new Candidate("D", 13), new Candidate("E", 12) };

            var votingBallots = new VotingBallots[] { new VotingBallots(state1Voting), new VotingBallots(state2Voting) };


            var expected = new Candidate[] { new Candidate("A", 47), new Candidate("B", 45), new Candidate("C", 43),
                                             new Candidate("D", 41), new Candidate("E", 39) };

            CollectionAssert.AreEqual(expected, Centralize(votingBallots));
        }

        private Candidate[] Centralize(VotingBallots[] votingBallots)
        {
            var a = new VotingBallots[] { };
            var centralizedVotingList = new Candidate[] { };
        }
    }
}

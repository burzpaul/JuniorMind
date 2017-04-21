using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizationOfElections
{
    class Election
    {
        private VotingBalot[] votingBallots;
        private Candidate[] candidates;
        private int index = 0;

        public Election(VotingBalot[] votingBallots)
        {
            this.votingBallots = votingBallots;
        }

        public Candidate[] CentralizeElection()
        {
            for (int i = 0; i < votingBallots.Length - 1; i++)
            {
                votingBallots[i].AddCandidatesAndAddTheirVotesFromBallots(votingBallots[i + 1]);
            }
           
            var unsortedResults = votingBallots[0].ReturnCandidatesArray();

            Candidate candidate;

            var candidatesOrderedeByVote = new CandidatesOrderedByVotes(unsortedResults);

            while (candidatesOrderedeByVote.GetNext(out candidate))
            {
                unsortedResults[index++] = candidate;
            }

            return unsortedResults;

        }
    }
}

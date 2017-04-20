using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizationOfElections
{
    class Election
    {
        public Candidate[] CentralizeVotes(VotingBalot[] votingBallots)
        {
            for (int i = 0; i < votingBallots.Length - 1; i++) 
            {
                votingBallots[i].AddCandidatesAndAddTheirVotesFromBallots(votingBallots[i + 1]);
            }
            return votingBallots[0].ReturnCandidatesArray();
        }
    }
}

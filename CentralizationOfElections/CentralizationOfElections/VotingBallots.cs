using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizationOfElections
{
    public class VotingBalot
    {
        private string vottingBalletName;
        private Candidate[] candidatesArray;

        public VotingBalot(string name, Candidate[] candidates)
        {
            this.vottingBalletName = name;

            new OrderAlphabetically(candidates);

            this.candidatesArray = candidates;
        }

        public void AddCandidatesAndAddTheirVotesFromBallots(VotingBalot votingBallet)
        {
            for (int i = 0; i < candidatesArray.Length; i++)
            {
                candidatesArray[i].AddVotes(votingBallet.candidatesArray[i]);
            }
        }

        public Candidate[] ReturnCandidatesArray()
        {
            return candidatesArray;
        }
    }
}

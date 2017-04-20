using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizationOfElections
{
    class VotingBallots
    {
        private string votingBallot;
        private Candidate[] candidate;

        public void VotingBallotName(string name)
        {
            this.votingBallot = name;
        }
   
        public VotingBallots(Candidate[] candidate)
        {
            this.candidate = candidate;
        }  
    }
}

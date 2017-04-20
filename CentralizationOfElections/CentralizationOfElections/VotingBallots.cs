using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizationOfElections
{
    class VotingBallot
    {
        private string votingLocation;
        private Candidate[] candidate;

        public VotingBallot(Candidate[] candidate)
        {
            this.candidate = candidate;
        }

        public void VotingLocationName(string name)
        {
            this.votingLocation = name;
        }
    }
}

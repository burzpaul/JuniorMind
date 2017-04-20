using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizationOfElections
{
    public class Candidate 
    {
        private string candidateName;
        private int numberOfVotes;

        public Candidate(string name, int votes)
        {
            this.candidateName = name;
            this.numberOfVotes = votes;
        }

        public void AddVotes(Candidate votesFromBallot)
        {
            numberOfVotes = numberOfVotes + votesFromBallot.numberOfVotes;
        }

        public bool IsSameCandidate(string name)
        {
            return candidateName.Equals(name);
        }

        public bool IsSameCandidate(Candidate other)
        {
            return candidateName.Equals(other.candidateName);
        }

        public bool HasMoreVotes(Candidate other)
        {
            return numberOfVotes > other.numberOfVotes;
        }
    }
}

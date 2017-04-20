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
        public void IncreaseVotes(int toBeAddedVotes)
        {
            numberOfVotes = numberOfVotes + toBeAddedVotes;
        }
    }
}

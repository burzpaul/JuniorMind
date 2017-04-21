using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizationOfElections
{
    class CandidatesOrderedByVotes
    {
        private Candidate[] candidate;
        private int index = 0;

        public CandidatesOrderedByVotes(Candidate[] candidate)
        {
            this.candidate = candidate;
            HeapSort();
        }

        public bool GetNext(out Candidate candidate)
        {
            if (index < this.candidate.Length)
            {
                candidate = this.candidate[index++];
                return true;
            }
            candidate = null;
            return false;
        }

        private void HeapSort()
        {
            int n = candidate.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref candidate[0], ref candidate[i]);

                Heapify(i, 0);
            }
        }

        private void Heapify(int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && candidate[left].HasMoreVotes(candidate[largest]))
            {
                largest = left;
            }
            if (right < n && candidate[right].HasMoreVotes(candidate[largest]))
            {
                largest = right;
            }
            if (largest != root)
            {
                Swap(ref candidate[root], ref candidate[largest]);
                Heapify(n, largest);
            }
        }

        private static void Swap(ref Candidate candidate1, ref Candidate candidate2)
        {
            var temp = candidate1;
            candidate1 = candidate2;
            candidate2 = temp;
        }
    }
}

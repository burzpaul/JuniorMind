using System;

namespace OrderWordsByNumberOfApparitionsInText
{
    public class HeapSort
    {
        
        public void HeapSorting(Word[] words)
        {
            int n = words.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(words, n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref words[0], ref words[i]);

                Heapify(words, i, 0);
            }
        }

        public void Heapify(Word[] words, int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && words[left].IsMoreCommon(words[largest]))
            {
                largest = left;
            }
            if (right < n && words[right].IsMoreCommon(words[largest]))
            {
                largest = right;
            }
            if (largest != root)
            {
                Swap(ref words[root], ref words[largest]);
                Heapify(words, n, largest);
            }
        }

        public void Swap(ref Word firstWord, ref Word words2)
        {
            var temp = firstWord;
            firstWord = words2;
            words2 = temp;
        }
    }
}

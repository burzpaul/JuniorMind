using System;

namespace OrderWordsByNumberOfApparitionsInText
{
    public class MostCommonWords
    {
        private Word[] words;

        public MostCommonWords(Word[] words)
        {
            this.words = words;
        }

        public Word[] Sort()
        {
            HeapSort();
            return words;
        }

        private void HeapSort()
        {
            int n = words.Length ;
            for (int i = n / 2 - 1; i >= 0; i--) 
            {
                Heapify(n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref words[0], ref words[i]);

                Heapify(i, 0);
            }
        }

        private void Heapify(int n, int root)
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
                Heapify(n, largest);
            }
        }

        private static void Swap(ref Word firstWord, ref Word words2)
        {
            var temp = firstWord;
            firstWord = words2;
            words2 = temp;
        }  
    }
}

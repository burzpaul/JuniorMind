using System;

namespace OrderWordsByNumberOfApparitionsInText
{
    public class GiveWordsArray
    {
        private Word[] words;

        public GiveWordsArray(Word[] words)
        {
            this.words = words;
        }

        public void HeapSorting()
        {
            int n = this.words.Length;
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

        public void Heapify(int n, int root)
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

        public void Swap(ref Word firstWord, ref Word words2)
        {
            var temp = firstWord;
            firstWord = words2;
            words2 = temp;
        }
    }
}

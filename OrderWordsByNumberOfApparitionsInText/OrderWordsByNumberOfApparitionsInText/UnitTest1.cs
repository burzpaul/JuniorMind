using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class MyClass
    {
        public WordClass[] OrderTheWordsByNumberOfAppearances(string text)
        {
            var words = SearchForWord(text.Split(' '));
            HeapSort(words);
            return words;
        }

        private WordClass[] SearchForWord(string[] textWords)
        {
            var words = new WordClass[] { };
            foreach (var currentWord in textWords)
            {
                var index = FindWordIndex(words, currentWord);
                if (index != -1)
                {
                    IncreaseAppearances(ref words[index]);
                    continue;
                }
                AddWord(ref words, currentWord);
            }
            return words;
        }

        private int FindWordIndex(WordClass[] words, string currentWord)
        {
            for (int index = 0; index < words.Length; index++)
            {
                if (CompareWords(words[index].GetWord(), currentWord))
                {
                    return index;
                }
            }
            return -1;
        }

        private bool CompareWords(string firstWord, string secondWord)
        {
            return string.Equals(firstWord, secondWord, StringComparison.InvariantCultureIgnoreCase);
        }

        private void IncreaseAppearances(ref WordClass word)
        {
            word.IncreaseNumberOfApparitions();
        }

        private void AddWord(ref WordClass[] words, string textWordNotIndexed)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = new WordClass();
            words[words.Length - 1].Details(textWordNotIndexed.ToLowerInvariant(), 1);
        }

        private void Swap(ref WordClass firstWord, ref WordClass words2)
        {
            var temp = new WordClass();
            temp = firstWord;
            firstWord = words2;
            words2 = temp;
        }

        private void HeapSort(WordClass[] words)
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

        private void Heapify(WordClass[] words, int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && words[left].GetNumberOfApparitions() > words[largest].GetNumberOfApparitions())
            {
                largest = left;
            }
            if (right < n && words[right].GetNumberOfApparitions() > words[largest].GetNumberOfApparitions())
            {
                largest = right;
            }
            if (largest != root)
            {
                Swap(ref words[root], ref words[largest]);
                Heapify(words, n, largest);
            }
        }

    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class MyClass
    {
        public Word[] OrderTheWordsByNumberOfAppearances(string text)
        {
            var words = SearchForWord(text.Split(' '));
            HeapSort(words);
            return words;
        }

        public Word[] SearchForWord(string[] textWords)
        {
            var words = new Word[] { };
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

        public void IncreaseAppearances(ref Word word)
        {
            word.IncreaseApparition();
        }

        public int FindWordIndex(Word[] words, string currentWord)
        {
            for (int index = 0; index < words.Length; index++)
            {
                if (words[index].EqualWords(currentWord)) 
                {
                    return index;
                }
            }
            return -1;
        }

        public void AddWord(ref Word[] words, string textWordNotIndexed)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = new Word(textWordNotIndexed);
            words[words.Length - 1].IncreaseApparition();
        }

        public void Swap(ref Word firstWord, ref Word words2)
        {
            var temp = new Word("");
            temp = firstWord;
            firstWord = words2;
            words2 = temp;
        }

        public void HeapSort(Word[] words)
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
    }
}
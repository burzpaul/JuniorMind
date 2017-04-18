using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class UnitTest1
    {
        public struct Word
        {
            public string theWord;
            public int numberOfApparitions;

            public Word(string theWord, int numberOfApparitions)
            {
                this.theWord = theWord;
                this.numberOfApparitions = numberOfApparitions;
            }
        }
        [TestMethod]
        public void Test_The_Number_Apparitions_Of_Key_Words()
        {
            var expected = new Word[] { new Word("two", 2), new Word("germany", 2), new Word("one", 3),
                                        new Word("pc", 3), new Word("word", 4) };

            CollectionAssert.AreEqual(expected, OrderTheWordsByNumberOfAppearances("word word word word pc pc pc germany germany one one one two two"));
        }
        [TestMethod]
        public void Test_The_Number_Apparitions_Of_Key_Words2()
        {
            var expected = new Word[] { new Word("ooo", 1), new Word("ccc", 2), new Word("abc", 3) };

            CollectionAssert.AreEqual(expected, OrderTheWordsByNumberOfAppearances("abc abc abc CCC CCC oOo"));
        }

        public Word[] OrderTheWordsByNumberOfAppearances(string text)
        {
            var words = SearchForWord(text.Split(' '));
            HeapSort(words);
            return words;
        }

        private Word[] SearchForWord(string[] textWords)
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

        private void IncreaseAppearances(ref Word word)
        {
            word.numberOfApparitions++;
        }

        private int FindWordIndex(Word[] words, string currentWord)
        {
            for (int index = 0; index < words.Length; index++)
            {
                if (CompareWords(words[index].theWord, currentWord))
                {
                    return index;
                }
            }
            return -1;
        }

        private void AddWord(ref Word[] words, string textWordNotIndexed)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = new Word(textWordNotIndexed.ToLowerInvariant(), 1);
        }

        private void HeapSort(Word[] words)
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

        private void Heapify(Word[] words, int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && words[left].numberOfApparitions > words[largest].numberOfApparitions)
            {
                largest = left;
            }
            if (right < n && words[right].numberOfApparitions > words[largest].numberOfApparitions)
            {
                largest = right;
            }
            if (largest != root)
            {
                Swap(ref words[root], ref words[largest]);
                Heapify(words, n, largest);
            }
        }

        private void Swap(ref Word firstWord, ref Word words2)
        {
            var temp = new Word();
            temp = firstWord;
            firstWord = words2;
            words2 = temp;
        }

        private bool CompareWords(string firstWord, string secondWord)
        {
            return string.Equals(firstWord, secondWord, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
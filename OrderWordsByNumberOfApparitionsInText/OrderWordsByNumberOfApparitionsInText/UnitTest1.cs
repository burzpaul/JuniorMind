using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class UnitTest1
    {
        public struct Words
        {
            public string theWord;
            public int numberOfApparitions;

            public Words(string theWord, int numberOfApparitions)
            {
                this.theWord = theWord;
                this.numberOfApparitions = numberOfApparitions;
            }
        }
        [TestMethod]
        public void Test_The_Number_Apparitions_Of_Key_Words()
        {
            string text = "word word word word pc pc pc germany germany one one one two two";

            var given = new Words[] { new Words("pc", 0), new Words("word", 0), new Words("germany", 0),
                                        new Words("two", 0), new Words("one", 0) };

            var expected = new Words[] { new Words("two", 2), new Words("germany", 2), new Words("pc", 3),
                                        new Words("one", 3), new Words("word", 4) };

            CollectionAssert.AreEqual(expected, OrderTheWordsByNumberOfApparitions(given, text));
        }
        [TestMethod]
        public void Test_The_Number_Apparitions_Of_Key_Words2()
        {
            string text = "abc abc abc CCC CCC oOo";

            var given = new Words[] { new Words("abc", 0), new Words("ccc", 0), new Words("ooo", 0) };

            var expected = new Words[] { new Words("ooo", 1), new Words("ccc", 2), new Words("abc", 3) };


            CollectionAssert.AreEqual(expected, OrderTheWordsByNumberOfApparitions(given, text));
        }
        public Words[] OrderTheWordsByNumberOfApparitions(Words[] words, string text)
        {
            SearchForWord(words, text.Split(' '));
            HeapSort(words);
            return words;
        }
        private void SearchForWord(Words[] words, string[] textWords)
        {
            for (int i = 0; i < words.Length; i++)
            {
                var currentWord = words[i].theWord;
                for (int index = 0; index < textWords.Length; index++)
                {
                    var currentTextWord = textWords[index].ToLower();
                    if (CompareWords(currentTextWord, currentWord))  
                    {
                        words[i].numberOfApparitions++;
                    }
                }
            }
        }

        private void HeapSort(Words[] words)
        {
            int n = words.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(words, n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref words[0],ref words[i]);

                Heapify(words, i, 0);
            }
        }

        private void Heapify(Words[] words, int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if(left < n && words[left].numberOfApparitions > words[largest].numberOfApparitions)
            {
                largest = left;
            }
            if (right < n && words[right].numberOfApparitions > words[largest].numberOfApparitions)
            {
                largest = right;
            }

            if(largest != root)
            {
                Swap(ref words[root], ref words[largest]);
                Heapify(words, n, largest);
            }
        }

        private void Swap(ref Words firstWord, ref Words words2)
        {
            var temp = new Words();
            temp = firstWord;
            firstWord = words2;
            words2 = temp;
        }

        private bool CompareWords(string firstWord, string secondWord)
        {
            return firstWord == secondWord;
        }
    }
}

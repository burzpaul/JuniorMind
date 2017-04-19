using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class SortByMostCommonTest
    {
        [TestMethod]
        public void TestIfSorted()
        {
            var words = new Word[] { new Word("third", 3), new Word("first", 1),
                                        new Word("fourth", 4), new Word("second", 2) };

            var expected = new Word[] { new Word("first", 1), new Word("second", 2),
                                        new Word("third", 3),new Word("fourth", 4),};

            var sort = new GiveWordsArray(words);
            sort.HeapSorting();

            Assert.AreEqual(0, CompareWords(expected, words) +
                CompareWordsByNumberOfApparitions(expected, words));
        }

        private int CompareWords(Word[] expected, Word[] actual)
        {
            int ok = 0;
            for (int i = 0; i < expected.Length; i++)
            {
                if (IsEqualTo(expected[i], actual[i]) == false)
                {
                    ok = 1;
                    break;
                }
            }
            return ok;
        }
        private int CompareWordsByNumberOfApparitions(Word[] expected, Word[] actual)
        {
            int ok = 0;
            for (int i = 0; i < expected.Length; i++)
            {
                if (IsNumberOfApparitionsEqualTo(expected[i], actual[i]) == false)
                {
                    ok = 1;
                    break;
                }
            }
            return ok;
        }
        bool IsEqualTo(Word firstWord, Word secondWord)
        {
            return firstWord.EqualWords(secondWord);
        }
        bool IsNumberOfApparitionsEqualTo(Word firstWord, Word secondWord)
        {
            return firstWord.EqualApparitions(secondWord);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class IndexWords
    {
        [TestMethod]
        public void Test_For_Search_For_Word_Function_And_Add_Word()
        {
            string text = "this words should be indexed";

            var expected = new Word[] { new Word("words"),
                        new Word("should"),new Word("be"),new Word("indexed"),new Word("this") };

            var actual = IndexWordsInText(text);

            Assert.AreEqual(0, CompareWords(expected, actual));
        }
        [TestMethod]
        public void Test_For_Search_And_For_Index_Words_By_Most_Common()
        {
            string text = "this this this this words words should should should be indexed";

            var expected = new Word[] { new Word("be", 1), new Word("indexed", 1), new Word("words", 2),
                        new Word("should",3),new Word("this",4) };

            var actual = IndexWordsInText(text);

            Assert.AreEqual(0, CompareWords(expected, actual) + CompareWordsByNumberOfApparitions(expected, actual));
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

        public Word[] IndexWordsInText(string text)
        {
            var words = SearchForWord(text.Split(' '));

            var heapsort = new GiveWordsArray(words);
            heapsort.HeapSorting();

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
    }
}
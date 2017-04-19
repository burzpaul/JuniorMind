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

            var expected = new Word[] { new Word("words", 1), new Word("should", 1), new Word("be", 1), new Word("indexed", 1), new Word("this", 1) };

            var actual = IndexWordsInText(text);

            Assert.AreEqual(true, actual[0].EqualWords(expected[0], false));
        }

        [TestMethod]
        public void Test_For_Search_And_For_Index_Words_By_Most_Common()
        {
            string text = "this this this this words words should should should be indexed";

            var expected = new Word[] { new Word("be", 1), new Word("indexed", 1), new Word("words", 2),
                        new Word("should",3),new Word("this",4) };

            var actual = IndexWordsInText(text);

            Assert.AreEqual(true, actual[0].EqualWords(expected[0], false));
        }

        public Word[] IndexWordsInText(string text)
        {
            Word[] words = SearchForWord(text.Split(' '));

            Word word;

            int index = 0;

            var common = new MostCommonWords(words);
            while (common.GetNext(out word) == true) 
            {
                words[index++] = word;
            }
            
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

        public int FindWordIndex(Word[] word, string currentWord)
        {
            for (int index = 0; index < word.Length; index++)
            {
                if (word[index].EqualWords(currentWord, false))     
                {
                    return index;
                }
            }
            return -1;
        }

        public void AddWord(ref Word[] word, string textWordNotIndexed)
        {
            Array.Resize(ref word, word.Length + 1);
            word[word.Length - 1] = new Word(textWordNotIndexed);
            word[word.Length - 1].IncreaseApparition();
        }
    }
}
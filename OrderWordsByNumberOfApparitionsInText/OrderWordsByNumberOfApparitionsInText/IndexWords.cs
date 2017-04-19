using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class IndexWords
    {
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
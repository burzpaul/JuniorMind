using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class UnitTest1
    {
        struct Words
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
        public void TestForSearchWords()
        {
            string text = "abc abc abc CCC CCC oOo";

            var given = new Words[] { new Words("abc", 0), new Words("ccc", 0), new Words("ooo", 0) };

            var expected = new Words[] { new Words("abc", 3), new Words("ccc", 2), new Words("ooo", 1) };

            var verifier = SearchForWord(given, text.Split(' '));

            CollectionAssert.AreEqual(expected, verifier);
        }
        private Words[] OrderTheWordsByNumberOfApparitions(Words[] words, string text)
        {
            SearchForWord(words, text.Split(' '));
            return null;
        }
        private Words[] SearchForWord(Words[] word, string[] textWords)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var currentWord = word[i].theWord;
                for (int index = 0; index < textWords.Length; index++)
                {
                    var currentTextWord = textWords[index].ToLower();
                    if (CompareWords(currentTextWord, currentWord))  
                    {
                        word[i].numberOfApparitions++;
                    }
                }
            }
            return word;
        }
        private bool CompareWords(string firstWord, string secondWord)
        {
            return firstWord == secondWord;
        }
    }
}

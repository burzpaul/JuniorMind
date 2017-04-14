using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class UnitTest1
    {
        struct Words
        {
            string word;
            int numberOfApparitions;
            public Words(string word, int numberOfApparitions)
            {
                this.word = word;
                this.numberOfApparitions = numberOfApparitions;
            }
        }
        [TestMethod]
        public void Test_The_Number_Apparitions_Of_Key_Words_()
        {
            string text = "word word word word pc pc pc germany germany one one one two two";

            var given = new Words[] { new Words("pc", 0), new Words("word", 0), new Words("germany", 0),
                                        new Words("two", 0), new Words("one", 0) };

            var expected = new Words[] { new Words("two", 2), new Words("germany", 2), new Words("pc", 3),
                                        new Words("one", 3), new Words("word", 4) };

            CollectionAssert.AreEqual(expected, OrderTheWordsByNumberOfApparitions(given, text));
        }
        private Words[] OrderTheWordsByNumberOfApparitions(Words[] words, string text)
        {
            return null;
        }
    }
}

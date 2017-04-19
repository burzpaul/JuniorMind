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

            var actual = new MostCommonWords(words).Sort();

            Assert.AreEqual(true, actual[0].EqualWords(expected[0], false));
        }

        [TestMethod]
        public void Test2IfSorted()
        {
            var words = new Word[] { new Word("third", 10), new Word("first", 4),
                                        new Word("fourth", 4), new Word("second", 2) };

            var expected = new Word[] { new Word("second", 2), new Word("first", 4),
                                        new Word("fourth", 4),new Word("third", 10)};

            var actual = new MostCommonWords(words).Sort();

            Assert.AreEqual(true, actual[0].EqualWords(expected[0], false));
        }
    }
}

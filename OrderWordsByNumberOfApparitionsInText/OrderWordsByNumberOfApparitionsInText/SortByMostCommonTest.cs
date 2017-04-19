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
            var words = new Word[] { new Word("third", 3), new Word("first", 1), new Word("fourth", 4), new Word("second", 2) };

            var expected = new Word[] { words[1], words[3], words[0], words[2] };

            Word word;
            var common = new MostCommonWords(words);

            Assert.IsTrue(common.GetNext(out word));
            Assert.AreEqual(words[1], word);
            Assert.IsTrue(common.GetNext(out word));
            Assert.IsTrue(common.GetNext(out word));
            Assert.IsTrue(common.GetNext(out word));
            Assert.AreEqual(words[2], word);
            Assert.IsFalse(common.GetNext(out word));
        }

        [TestMethod]
        public void Test2IfSorted()
        {
            var words = new Word[] { new Word("third", 10), new Word("first", 4),
                                        new Word("fourth", 4), new Word("second", 2) };

            var expected = new Word[] { words[3], words[2], words[1], words[0]};

            Word word;
            var common = new MostCommonWords(words);

            Assert.IsTrue(common.GetNext(out word));
            Assert.AreEqual(words[3], word);
            Assert.IsTrue(common.GetNext(out word));
            Assert.IsTrue(common.GetNext(out word));
            Assert.IsTrue(common.GetNext(out word));
            Assert.AreEqual(words[0], word);
            Assert.IsFalse(common.GetNext(out word));
        }
    }
}

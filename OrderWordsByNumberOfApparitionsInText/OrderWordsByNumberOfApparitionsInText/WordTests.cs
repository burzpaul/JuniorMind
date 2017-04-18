using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class WordTests 
    {
        [TestMethod]
        public void Test1()
        {
            string text = "word word word word pc pc pc germany germany one one one two two";

            var expected = new Word[] { new Word("two"), new Word("germany"), new Word("one"),
                                        new Word("pc"), new Word("word") };

            var actual = new MyClass().OrderTheWordsByNumberOfAppearances(text);

            Assert.AreEqual(0, CompareWords(expected, actual));
        }
        [TestMethod]
        public void Test2()
        {
            string text = "abc abc abc CCC CCC oOo";

            var expected = new Word[] { new Word("ooo"), new Word("ccc"), new Word("abc") };

            var actual = new MyClass().OrderTheWordsByNumberOfAppearances(text);
            
            Assert.AreEqual(0, CompareWords(expected, actual));

        }
        [TestMethod]
        public void Test3()
        {
            string text = "W I o P Ww WW OO PP";

            var expected = new Word[] { new Word("w"), new Word("o"), new Word("p"), new Word("i"), new Word("oo"), new Word("pp"), new Word("ww") };

            var actual = new MyClass().OrderTheWordsByNumberOfAppearances(text);

            Assert.AreEqual(0,CompareWords(expected,actual));
        }

        private int CompareWords(Word[] expected, Word[] actual)
        {
            int ok = 0;
            for (int i = 0; i < expected.Length; i++)
            {
                if (IsEqualTo(expected[i], actual[i]) == false)
                {
                    ok = 1;
                }
            }
            return ok;
        }

        bool IsEqualTo(Word firstWord, Word secondWord)
        {
           return firstWord.EqualWords(secondWord);  
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class WordTests 
    {
        [TestMethod]
        public void Test_For_Word_Function_Without_Number_Of_Apparitions()
        {
            var word = new Word("abc");
            Assert.AreEqual(true,word.EqualWords("abc"));
        }
        [TestMethod]
        public void Test_For_Word_Functon_With_Number_Of_Apparitions_Test_Number_Of_Apparitions()
        {
            var word = new Word("abc", 2);
            Assert.AreEqual(true, word.EqualApparitions(2));
        }
        [TestMethod]
        public void Test_For_Same_Word_But_Different_Numbers_Of_Apparitions()
        {
            var word1 = new Word("same", 1);
            var word2 = new Word("same", 2);
            if (word1.EqualWords(word2))
                Assert.AreEqual(true, word2.IsMoreCommon(word1));
        }
        [TestMethod]
        public void Test_For_Increase_Apparitions_Function()
        {
            var word1 = new Word("word", 1);
            word1.IncreaseApparition();
            var word2 = new Word("xyz", 2);
            Assert.AreEqual(true, word1.EqualApparitions(word2));
        }
    }
}

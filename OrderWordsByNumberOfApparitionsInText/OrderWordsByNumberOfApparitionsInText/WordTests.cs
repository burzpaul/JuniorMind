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
        public void Test_For_Word_Functon_With_Number_Of_Apparitions()
        {
            var word = new Word("abc", 2);
            Assert.AreEqual(true, word.EqualApparitions(2));
        }
    }
}

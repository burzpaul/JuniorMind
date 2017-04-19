using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByNumberOfApparitionsInText
{
    [TestClass]
    public class WordTests 
    {
        [TestMethod]
        public void Test_ForWord_Function_Without_Number_Of_Apparitions()
        {
            var word = new Word("abc");
            Assert.AreEqual(true,word.EqualWords("abc"));
        }
    }
}

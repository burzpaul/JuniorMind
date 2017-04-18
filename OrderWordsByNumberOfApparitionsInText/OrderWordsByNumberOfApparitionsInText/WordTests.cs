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

            var actual = new MyClass().OrderTheWordsByNumberOfAppearances(text);

            var expected = new WordClass();
            expected.Details("two", 2);
            
            Assert.AreEqual(expected.GetWord(), actual[0].GetWord());
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReplaceCharacterInString
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("Pitbull", ReplaceInString("Pbull","itb",'b'));
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("abcd", ReplaceInString("x", "abcd", 'x'));
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("antidisestablishmentarianism", ReplaceInString("antxdxsestablxshmentarxanxsm", "i", 'x'));
        }
        public string ReplaceInString(string givenString, string replaceString, char characterToReplace)
        {
            if (givenString.Length > 0)
            {
                string temporary = ReplaceInString(givenString.Substring(1, givenString.Length - 1), replaceString, characterToReplace);
                if (givenString[0] == characterToReplace) return replaceString + temporary;
                return givenString[0] + temporary;
            }
            return givenString;
        }
    }
}

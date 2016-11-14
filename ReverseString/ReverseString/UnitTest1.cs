using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseString
{
    [TestClass]
    public class MyClass
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("gfedcba", ReverseTheString("abcdefg"));
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("lac", ReverseTheString("cal"));
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("a", ReverseTheString("a"));
        }
        public string ReverseTheString(string givenString)
        {
            if (givenString.Length == 1) return givenString;
            return givenString.Substring(givenString.Length - 1) + (givenString.Length > 2 ?ReverseTheString(givenString.Substring(0,givenString.Length -1)) : givenString.Substring(0,1));    
        }
    }
}

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
        public string ReverseTheString(string givenString)
        {
            return null;
        }
    }
}

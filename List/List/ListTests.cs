using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace List
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void Add_Test()
        {
            var list = new List<string> { "a", "b", "c" };
            list.Add("d");
            CollectionAssert.AreEqual(new[] { "a", "b", "c","d" }, list.ToArray());
        }
        [TestMethod]
        public void Count_Test()
        {
            var list = new List<int> { 1, 2, 3, 4 };

            Assert.AreEqual(4, list.Count);
        }
        [TestMethod]
        public void Clear_Test()
        {
            var list = new List<string> { "a", "b", "c" };

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Contains_Test()
        {
            var list = new List<string> { "a", "b", "c" };

            Assert.IsTrue(list.Contains("b"));
        }
        [TestMethod]
        public void CopyTo_Test()
        {
            var list = new List<char> { 'p', 'a', 'u', 'l' };
            var listCopy = new char[list.Count];

            list.CopyTo(listCopy, 0);

            CollectionAssert.AreEqual(listCopy ,list.ToArray());
        }
        [TestMethod]
        public void Index_Of_Test()
        {
            var list = new List<string>() { "a", "b", "c" };

            Assert.AreEqual(1, list.IndexOf("b"));
        }
        [TestMethod]
        public void Insert_Test()
        {
            var list = new List<string> { "a", "b", "c" };
            list.Insert(2, "c");

            var b = list.GetEnumerator();
            b.MoveNext();
            b.MoveNext();
            b.MoveNext();
            Assert.AreEqual("c", b.Current);
        }
        [TestMethod]
        public void Remove_Test()
        {
            var list = new List<string> { "a", "b", "c" };

            list.Remove("a");

            Assert.IsFalse(list.Contains("a"));

            var b = list.GetEnumerator();
            b.MoveNext();

            Assert.AreEqual("b", b.Current);
        }
        [TestMethod]
        public void RemoveAt_Test()
        {
            var list = new List<double> { 2.21, 5.32, 7.89, 9.72 };

            list.RemoveAt(2);

            CollectionAssert.AreEqual(new[] { 2.21, 5.32, 9.72 }, list.ToArray());
        }
    }
}

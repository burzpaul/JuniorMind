using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class ListsTests
    {
        [TestMethod]
        public void Add_Test()
        {
            var a = new List<string>();
            a.Add("a");
            a.Add("b");
            a.Add("c");
            var b = a.GetEnumerator();
            b.MoveNext();
            Assert.AreEqual("a", b.Current);

        }
        [TestMethod]
        public void Insert_Test()
        {
            var list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("d");
            list.Insert(2, "c");

            var b = list.GetEnumerator();
            b.MoveNext();
            b.MoveNext();
            b.MoveNext();
            Assert.AreEqual("c", b.Current);
        }
        [TestMethod]
        public void Clear_Test()
        {
            var list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Contains_Test()
        {
            var list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            Assert.IsTrue(list.Contains("b"));
        }
        [TestMethod]
        public void Index_Of_Test()
        {
            var list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            Assert.AreEqual(1, list.IndexOf("b"));
        }
        [TestMethod]
        public void Remove_Test()
        {
            var list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            list.Remove("a");

            Assert.IsFalse(list.Contains("a"));

            var b = list.GetEnumerator();
            b.MoveNext();

            Assert.AreEqual("b",b.Current);
        }
    }
}

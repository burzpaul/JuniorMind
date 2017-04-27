using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    [TestClass]
    public class LinkedListsTests
    {
        [TestMethod]
        public void Add_AddLast_Test()
        {
            var list = new LinkedList<string> { "a", "b" };

            list.Add("c");

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, list.ToArray());
        }
        [TestMethod]
        public void AddFirst_Test()
        {
            var list = new LinkedList<int> { 1, 2, 4 };

            list.AddFirst(0);

            CollectionAssert.AreEqual(new[] { 0, 1, 2, 4 }, list.ToArray());
        }
        [TestMethod]
        public void AddAfter_Test()
        {
            var list = new LinkedList<int> { 1, 2, 4 };

            list.AddAfter(list.Find(2), 3);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, list.ToArray());

        }
        [TestMethod]
        public void AddBefore_Test()
        {
            var list = new LinkedList<string> { "one", "three" };

            list.AddBefore(list.Find("three"), "two");

            CollectionAssert.AreEqual(new[] { "one", "two", "three" }, list.ToArray());
        }
        [TestMethod]
        public void Count_Test()
        {
            var list = new LinkedList<int> { 1, 1, 2, 2, 3, 123, 13 };
            Assert.AreEqual(7, list.Count);
        }
        [TestMethod]
        public void Clear_Test()
        {
            var list = new LinkedList<char> { 'a', 'b', 'c', 'd' };

            list.Clear();

            Assert.IsNull(list.First());
        }
        [TestMethod]
        public void Find_Last_Test()
        {
            var list = new LinkedList<string> { "one", "three", "one", "two", "one" };
            var a = list.FindLast("one");

            Assert.AreEqual(null, a.Next.Value);
        }
        [TestMethod]
        public void Contains_Test_True()
        {
            var list = new LinkedList<string> { "one", "three", "one", "two", "one" };

            Assert.AreEqual(true, list.Contains("two"));
        }
        [TestMethod]
        public void Contains_Test_False()
        {
            var list = new LinkedList<string> { "one", "three", "one", "two", "one" };

            Assert.AreEqual(false, list.Contains("four"));

        }
        [TestMethod]
        public void Remove_Test_True()
        {
            var list = new LinkedList<char> { 'a', 'b', 'c', 'd' };

            list.Remove('c');

            Assert.AreEqual(false, list.Contains('c'));
        }
        [TestMethod]
        public void Remove_Test_False()
        {
            var list = new LinkedList<string> { "a", "b", "a" };

            var a = list.Remove("d");

            Assert.AreEqual(false, a);

        }
        [TestMethod]
        public void Remove_First_Test()
        {
            var list = new LinkedList<string> { "a", "b" };

            list.RemoveFirst();

            CollectionAssert.AreEqual(new[] { "b" }, list.ToArray());
        }
        [TestMethod]
        public void Remove_Last_Test()
        {
            var list = new LinkedList<string> { "a", "b", "a" };

            list.RemoveLast();

            CollectionAssert.AreEqual(new[] { "a", "b" }, list.ToArray());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Exception_Test_ArgumentNullException()
        {
            var list = new LinkedList<string> { "a", "b", "a" };

            list.AddAfter(null, "c"); //InvalidOperationException
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Exception_Test_InvalidOperationException()
        {
            var list = new LinkedList<string> { "a", "b", "a" };

            list.AddAfter(list.Find("d"), "c");
        }

    }
}

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
        public void List_Id_Test_False()
        {
            var list = new LinkedList<string>("1") { "a", "b" };
            var list2 = new LinkedList<string>("2") { "a", "b" };

            Assert.AreEqual(false, list.IsSameList(list2));
        }
        [TestMethod]
        public void List_Id_Test_True()
        {
            var list = new LinkedList<string>("1") { "a", "b" };
            var list2 = new LinkedList<string>("1") { "a", "b" };

            Assert.AreEqual(true, list.IsSameList(list2));
        }
        [TestMethod]
        public void Add_AddLast_Test()
        {
            var list = new LinkedList<string>("1d1v") { "a", "b" };

            list.Add("c");

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, list.ToArray());
        }
        [TestMethod]
        public void AddFirst_Test()
        {
            var list = new LinkedList<int>("list") { 1, 2, 4 };

            list.AddFirst(0);

            CollectionAssert.AreEqual(new[] { 0, 1, 2, 4 }, list.ToArray());
        }
        [TestMethod]
        public void AddAfter_Test()
        {
            var list = new LinkedList<int>("list") { 1, 2, 4 };


            list.AddAfter(list.NodeIndex(1), 3);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, list.ToArray());

        }
        [TestMethod]
        public void AddBefore_Test()
        {
            var list = new LinkedList<string>("list") { "one", "three" };

            list.AddBefore(list.Find("three"), "two");

            CollectionAssert.AreEqual(new[] { "one", "two", "three" }, list.ToArray());
        }
        [TestMethod]
        public void Count_Test()
        {
            var list = new LinkedList<int>("list") { 1, 1, 2, 2, 3, 123, 13 };
            Assert.AreEqual(7, list.Count);
        }
        [TestMethod]
        public void Find_Last_Test()
        {
            var list = new LinkedList<string>("list") { "one", "three", "one", "two", "one" };
            var a = list.FindLast("one");

            Assert.AreEqual(null, a.Next.Value);
        }
        [TestMethod]
        public void Contains_Test_True()
        {
            var list = new LinkedList<string>("list") { "one", "three", "one", "two", "one" };

            Assert.AreEqual(true, list.Contains("two"));
        }
        [TestMethod]
        public void Contains_Test_False()
        {
            var list = new LinkedList<string>("list") { "one", "three", "one", "two", "one" };

            Assert.AreEqual(false, list.Contains("four"));

        }
        [TestMethod]
        public void Remove_Test_True()
        {
            var list = new LinkedList<char>("list") { 'a', 'b', 'c', 'd' };

            list.Remove('c');

            Assert.AreEqual(false, list.Contains('c'));
        }
        [TestMethod]
        public void Remove_Test_False()
        {
            var list = new LinkedList<string>("list") { "a", "b", "a" };

            var a = list.Remove("d");

            Assert.AreEqual(false, a);

        }
        [TestMethod]
        public void Remove_First_Test()
        {
            var list = new LinkedList<string>("list") { "a", "b" };

            list.RemoveFirst();

            CollectionAssert.AreEqual(new[] { "b" }, list.ToArray());
        }
        [TestMethod]
        public void Remove_Last_Test()
        {
            var list = new LinkedList<string>("list") { "a", "b", "a" };

            list.RemoveLast();

            CollectionAssert.AreEqual(new[] { "a", "b" }, list.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_After_Exception_Test_ArgumentNullException()
        {
            var list = new LinkedList<string>("list") { "a", "b", "a" };

            list.AddAfter(null, "c"); //ArgumentNullException;

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_After_Exception_Test_InvalidOperationException()
        {
            var list = new LinkedList<string>("list1") { "a", "b", "a" };
            var list2 = new LinkedList<string>("list2") { "d" };

            var temp = list2.Find("d");

            list.AddAfter(temp, "e"); //InvalidOperationException	
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_Before_Exception_Test_ArgumentNullException()
        {
            var list = new LinkedList<string>("list") { "a", "b", "a" };

            list.AddBefore(null, "c"); //ArgumentNullException;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_Before_Exception_Test_InvalidOperationException()
        {
            var list = new LinkedList<string>("list1") { "a", "b", "a" };
            var list2 = new LinkedList<string>("list2") { "a" };

            var temp = list2.Find("a");

            list.AddBefore(temp, "c"); //InvalidOperationException	
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_Exception_Test_ArgumentNullException()
        {
            var list = new LinkedList<string>("1@31") { "a", "b", "a" };

            var toRemove = list.Find("d");

            list.Remove(toRemove); //ArgumentNullException	
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_Exception_Test_InvalidOperationException()
        {
            var list = new LinkedList<string>("list1") { "a", "b", "a" };

            var list2 = new LinkedList<string>("list2") { "a", "b", "a" };

            var toRemove = list2.Find("b");

            list.Remove(toRemove); //InvalidOperationException		
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_First_Exception_Invalid_Operation_Test()
        {
            var list = new LinkedList<string>("first") { };

            list.RemoveFirst();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_Last_Exception_Invalid_Operation_Test()
        {
            var list = new LinkedList<string>("123") { };

            list.RemoveLast();
        }

        [TestMethod]
        public void Random()
        {

        }
    }
}

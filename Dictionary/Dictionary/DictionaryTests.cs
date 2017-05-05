using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void Count_Test()
        {
            var dictionary = new Dictionary<string, int>(3) { { "zero", 0 }, { "one", 1 }, { "two", 2 } };

            Assert.AreEqual(3, dictionary.Count);
        }
        [TestMethod]
        public void Contains_Key_True()
        {
            var dictionary = new Dictionary<string, int>(2) { { "one", 1 }, { "two", 2 } };

            Assert.IsTrue(dictionary.ContainsKey("one"));
        }
        [TestMethod]
        public void Contains_Key_False()
        {
            var dictionary = new Dictionary<string, int>(2) { { "one", 1 }, { "two", 2 } };

            Assert.IsFalse(dictionary.ContainsKey("three"));
        }
        [TestMethod]
        public void Contains_Key_Value_Pair_True()
        {
            var dictionary = new Dictionary<char, int>(2) { { 'a', 1 }, { 'b', 4 } };

            Assert.IsTrue(dictionary.Contains(new KeyValuePair<char, int>('a', 1)));
        }
        [TestMethod]
        public void Contains_Key_Value_Pair_False()
        {
            var dictionary = new Dictionary<char, int>(2) { { 'a', 1 }, { 'b', 2 } };

            Assert.IsFalse(dictionary.Contains(new KeyValuePair<char, int>('c', 3)));
        }
        [TestMethod]
        public void TValue_Test_Get()
        {
            var dictionary = new Dictionary<double, int>(4) { { 1.21, 0 }, { 32.1, 1 }, { 22.5, 3 }, { 656.4, 4 } };

            Assert.AreEqual(3,dictionary[22.5]);
        }
        [TestMethod]
        public void TValue_Test_Set()
        {
            var dictionary = new Dictionary<double, int>(4) { { 1.21, 0 }, { 32.1, 1 }, { 22.5, 3 }, { 656.4, 4 } };

            dictionary[22.5] = 321;

            Assert.AreEqual(321, dictionary[22.5]);
        }
        [TestMethod]
        public void Remove_Test()
        {
            var dictionary = new Dictionary<char, int>(4) { { 'a', 1 }, { 'b', 2 }, { 'c', 3 }, { 'd', 4 } };

            dictionary.Remove('b');

            Assert.IsFalse(dictionary.Contains(new KeyValuePair<char, int>('b', 2)));
        }
        [TestMethod]
        public void Remove_With_Conflicts()
        {
            var dictionary = new Dictionary<int, string>(10) { { 1, "zero" }, { 11, "one" }, { 2, "two" }, { 21, "three" } };

            dictionary.Remove(11);

            Assert.IsTrue(dictionary.Contains(new KeyValuePair<int, string>(1, "zero")));
            Assert.IsFalse(dictionary.Contains(new KeyValuePair<int, string>(11, "one")));
        }
        [TestMethod]
        public void Clear_Test()
        {
            var dictionary = new Dictionary<int, string>(5) { { 1, "a" }, { 2, "b" }, { 3, "c" }, { 4, "d" }, { 5, "e" } };

            dictionary.Clear();

            Assert.IsFalse(dictionary.Contains(new KeyValuePair<int, string>(1, "a")));
            Assert.IsFalse(dictionary.Contains(new KeyValuePair<int, string>(2, "b")));
            Assert.IsFalse(dictionary.Contains(new KeyValuePair<int, string>(3, "c")));
            Assert.IsFalse(dictionary.Contains(new KeyValuePair<int, string>(4, "d")));
            Assert.IsFalse(dictionary.Contains(new KeyValuePair<int, string>(5, "e")));
        }
        [TestMethod]
        public void Enumerator_Test()
        {
            var dictionary = new Dictionary<int, string>(10) { { 1, "zero" }, { 11, "one" }, { 2, "two" }, { 21, "three" } };

            var actual = dictionary.GetEnumerator();

            actual.MoveNext();

            Assert.AreEqual(actual.Current,new KeyValuePair<int,string>(1,"zero"));

            actual.MoveNext();

            Assert.AreEqual(actual.Current, new KeyValuePair<int, string>(11, "one"));
        }
        [TestMethod]
        public void Next_Free_Space_Test()
        {
            var dictionary = new Dictionary<string, int>(1) { { "one", 1 } };

            dictionary.Remove("one");

            dictionary.Add("four", 4);

            Assert.IsTrue(dictionary.Contains(new KeyValuePair<string, int>("four", 4)));
        }

        [TestMethod]
        public void Next_Free_Space_With_Multiple_Test()
        {
            var dictionary = new Dictionary<string, int>(5) { { "zero", 123}, { "one", 1 }, { "two", 12 }, { "five", 325 }, { "six", 6232 } };

            dictionary.Remove("one");
            dictionary.Remove("five");

            dictionary.Add("four", 4);
            dictionary.Add("three", 3);
            

            Assert.IsTrue(dictionary.ContainsKey("three"));
            Assert.IsTrue(dictionary.ContainsKey("four"));
        }
    }
}

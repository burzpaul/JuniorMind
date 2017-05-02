using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_Test()
        {
            var head = new Node<string>(null, "a", null, new Guid());

            Assert.AreEqual(true, head.Value.Equals("a"));
        }
    }
}

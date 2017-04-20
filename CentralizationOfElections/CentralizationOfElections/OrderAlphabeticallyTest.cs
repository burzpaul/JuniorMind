using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizationOfElections
{
    [TestClass]
    public class OrderAlphabeticallyTest
    {
        [TestMethod]
        public void See_If_In_Alphabetical_Order()
        {
            var state2 = new Candidate[] { new Candidate("D", 13), new Candidate("E", 12), new Candidate("B", 9),
                                                            new Candidate("A", 6), new Candidate("C", 4) };

            var expected = new Candidate[] { state2[3] };

            var sortedAlphabetically = new OrderAlphabetically(state2);

            Candidate candidate;

            Assert.IsTrue(sortedAlphabetically.GetNext(out candidate));
            Assert.AreEqual(true, expected[0].IsSameCandidate(candidate));
        }
    }
}

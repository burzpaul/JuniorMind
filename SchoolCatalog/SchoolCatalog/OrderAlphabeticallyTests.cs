using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class OrderAlphabeticallyTests
    {
        [TestMethod]
        public void Test_If_Ordered_Alphabetically()
        {
            var students = new Student[] { new Student("Paul", new Subject[] { }),
                                          new Student("Clark",new Subject[]{ }),
                                          new Student("Alex", new Subject[] { }),
                                          new Student("Seinfeld",new Subject[]{ })};

            var expected = new Student[] { students[2] };

            var sortedAlphabetically = new OrderAlphabetically(expected);

            Student student;

            Assert.IsTrue(sortedAlphabetically.GetNext(out student));
            Assert.AreEqual(true, expected[0].IsSameStudent(student));
        }
    }
}

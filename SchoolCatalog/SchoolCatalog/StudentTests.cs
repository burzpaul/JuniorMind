using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Test_If_Student_Created()
        {
            var subjects = new Subject[] { new Subject("Economics"), new Subject("Literature") };

            var students = new Student[] { new Student("Carl", subjects), new Student("Richard", subjects) };

            Assert.AreEqual(true, students[1].IsSameStudent("Richard"));
        }
    }
}

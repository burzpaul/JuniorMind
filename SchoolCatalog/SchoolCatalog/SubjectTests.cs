using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class SubjectTests
    {
        [TestMethod]
        public void Test_If_Subject_Created()
        {
            var subjects = new Subject[] { new Subject("Economics"), new Subject("Literature") };

            Assert.AreEqual(true, subjects[0].IsSameSubject("Economics"));
        }
        [TestMethod]
        public void Test_Add_Grade_Method()
        {
            var subject = new Subject("Math", new Grades(new int[] { 3, 3, 3 }));

            subject.AddGrade(10);

            Assert.AreEqual(4.75, subject.GeneralAverage(), 1);
        }
    }
}

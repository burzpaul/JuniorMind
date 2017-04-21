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
        [TestMethod]
        public void Test_Add_Subject_Method()
        {
            var student = new Student("Carl", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 9 })) });

            var newSubject = new Subject("Math", new Grades(new int[] { 12, 2, 3 }));

            student.AddSubject(newSubject);

            var gpaTotal = student.GeneralAverage();

            Assert.AreEqual(13.16, gpaTotal,1);
        }
    }
}

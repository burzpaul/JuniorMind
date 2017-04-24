using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class StudentsWithLowestGPATests
    {
        [TestMethod]
        public void Students_With_Lowest_Gpa ()
        {
            var students = new Student[] { new Student("Carl", new Subject[] { new Subject("Economics", new Grades(new int[] { 10, 7, 10, 10 })) }),
                                            new Student("Medusa", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 2 })) }),
                                            new Student("Trump", new Subject[] { new Subject("Economics", new Grades(new int[] { 10, 10, 10, 10 })) }),
                                            new Student("Melania", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 5 })) }),
                                            new Student("Tuck", new Subject[] { new Subject("Economics", new Grades(new int[] { 10, 10, 8, 7 })) }),
                                            new Student("Tom", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 10 })) })};

            var expected = students[1];

            var expcted2 = students[3];

            var studentsWithLowestGPA = new StudentsWithLowestGPA(students);

            Student student;

            Assert.IsTrue(studentsWithLowestGPA.GetNext(out student));
            Assert.AreEqual(true, expected.IsSameStudent(student));
            Assert.IsTrue(studentsWithLowestGPA.GetNext(out student));
            Assert.AreEqual(true, expcted2.IsSameStudent(student));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class StudentsWithMostHighestGradeTests
    {
        [TestMethod]
        public void Find_The_Students_With_The_Most_Highest_Grade()
        {
            var students = new Student[] { new Student("Carl", new Subject[] { new Subject("Economics", new Grades(new int[] { 10, 7, 10, 10 })) }),
                                            new Student("Medusa", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 2 })) }),
                                            new Student("Trump", new Subject[] { new Subject("Economics", new Grades(new int[] { 10, 10, 10, 10 })) }),
                                            new Student("Melania", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 5 })) }),
                                            new Student("Tuck", new Subject[] { new Subject("Economics", new Grades(new int[] { 10, 10, 8, 7 })) }),
                                            new Student("Tom", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 10 })) })};
            var studentWithMostHigherGrade = students[2];

            var actual = new StudentsWithMostHighestGrade(students);

            Assert.AreEqual(true, studentWithMostHigherGrade.IsSameStudent(actual));
        }
    }
}

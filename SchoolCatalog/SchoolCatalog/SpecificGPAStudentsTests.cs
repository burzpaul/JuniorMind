using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class SpecificGPAStudentsTests
    {
        [TestMethod]
        public void Test_If_Specific_GPAStudents_Are_Found()
        {
            var students = new Student[] { new Student("Carl", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 4, 9 })) }),
                                            new Student("Medusa", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 12 })) }),
                                            new Student("Trump", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 9 })) }),
                                            new Student("Davis", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 10 })) })};

            var specificGPA = 7.5;

            var specificGPAStudents = new SpecificGPAStudents(specificGPA, students);

            var expected = new Student("Trump", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 7, 8, 9 })) });

            Student student;

            Assert.IsTrue(specificGPAStudents.SearchForStudents(out student));
            Assert.AreEqual(true, expected.IsSameStudent(student));
        }
    }
}

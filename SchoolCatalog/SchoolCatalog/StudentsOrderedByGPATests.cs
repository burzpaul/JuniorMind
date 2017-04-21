using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class StudentsOrderedByGPATests
    {
        [TestMethod]
        public void Test_If_Ordered_By_GPA()
        {
            var students = new Student[] { new Student("Carl", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 6, 6 })),
                                                                               new Subject("Literature",new Grades(new int[] { 6, 6, 6 }))}),

                                           new Student("Richard", new Subject[] { new Subject("Economics", new Grades(new int[] { 5, 6, 6 })),
                                                                               new Subject("Literature",new Grades(new int[] { 6, 6, 6 }))}),
                                           new Student("Alex", new Subject[] { new Subject("Economics", new Grades(new int[] { 8, 8, 6 })),
                                                                               new Subject("Literature",new Grades(new int[] { 6, 7, 6 }))})};

            var expected = new Student[] { students[2] };

            var gpaSorted = new StudentsOrderedByGPA(students);

            Student student;

            Assert.IsTrue(gpaSorted.GetNext(out student));
            Assert.AreEqual(true, expected[0].IsSameStudent(student));
        }
    }
}

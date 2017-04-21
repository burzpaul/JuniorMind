using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class SchoolClassTests
    {
        [TestMethod]
        public void Test_If_School_Class_Created()
        {
            var students = new Student[] { new Student("Carl", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 6, 6 })),
                                                                               new Subject("Literature",new Grades(new int[] { 6, 6, 6 }))}),

                                           new Student("Richard", new Subject[] { new Subject("Economics", new Grades(new int[] { 6, 6, 6 })),
                                                                               new Subject("Literature",new Grades(new int[] { 6, 6, 6 }))}) };

            var schoolClass = new SchoolClass[] { new SchoolClass("FirstClass", students) };

            Assert.AreEqual(true, schoolClass[0].IsSameClass("FirstClass"));
        }
        [TestMethod]
        public void Test_Add_Student_Method()
        {
            var students = new Student[] { new Student("Carl", new Subject[] { new Subject("Economics") }) };

            var newStudent = new Student("May", new Subject[] { new Subject("Math") });

            var schoolClass = new SchoolClass("FirstClass", students);

            var updatedSchoolClass = schoolClass;

            updatedSchoolClass.AddStudent(newStudent);

            schoolClass.AddStudent(newStudent);

            Assert.AreEqual(true, schoolClass.Equals(updatedSchoolClass));
        }
    }
}

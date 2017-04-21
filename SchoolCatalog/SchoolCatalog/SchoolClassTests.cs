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

            var schoolClass1 = new SchoolClass[] { new SchoolClass("FirstClass", students) };

            Assert.AreEqual(true, schoolClass1[0].IsSameClass("FirstClass"));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class GradesTests
    {
        [TestMethod]
        public void Test_If_Grades_Created()
        {
            int[] grades = new int[] { 6, 7, 8, 9 };

            var student1Grades = new Grades(grades);

            Assert.AreEqual(true, student1Grades.AreSameGrades(grades));
        }
    }
}

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

            var studentGeneralAverage = new Student[] { new Student("Carl", 
                                                        new Subject[] {
                                                        new Subject("Economics", 
                                                        new Grades(new int[] { 6, 7, 8, 9 })) }) };

            Assert.AreEqual(7.5, studentGeneralAverage[0].GeneralAverage(), 1);
        }
        [TestMethod]
        public void Test_For_Add_Grade_Method()
        {
            int newGrade = 5;

            var grades = new Grades(new int[] { 1, 2, 3, 4 });

            grades.AddGrade(newGrade);

            Assert.AreEqual(3, grades.GeneralAverage(), 1);
        }
    }
}

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
    }
}

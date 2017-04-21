using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCatalog
{
    [TestClass]
    public class OrderAlphabeticallyTests
    {
        [TestMethod]
        public void Test_If_Ordered_Alphabetically()
        {
            var student = new Student[] { new Student("Paul", new Subject[] { }),
                                          new Student("Clark",new Subject[]{ }),
                                          new Student("Alex", new Subject[] { }),
                                          new Student("Seinfeld",new Subject[]{ })};


        }
    }
}

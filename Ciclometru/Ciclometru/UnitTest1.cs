using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciclometru
{
    [TestClass]
    public class MyClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            double[] rotationsForEverySecond = new double[1];
            var cyclist = new Cyclist[] { new Cyclist("Dave", 27.4, 320, GetRotationForEverySecond(rotationsForEverySecond))
                                          ,new Cyclist("Alex",25.7,320,rotationsForEverySecond)};
            Assert.AreEqual(320, TotalDistanceForAllCyclists(cyclist));
        }
        private double TotalDistanceForAllCyclists(Cyclist[] cyclist)
        {

            return cyclist[2].rotationsForEverySecond[1];
        }
        private double[] GetRotationForEverySecond(double[] rotationsForEverySecond)
        {

        }
        struct Cyclist
        {
            public string name;
            public double diameter;
            public double totalTimeInSeconds;
            public double[] rotationsForEverySecond;
            public Cyclist(string name, double diameter, double totalTimeInSeconds, double[] rotationsForEverySecond)
            {
                this.name = name;
                this.diameter = diameter;
                this.totalTimeInSeconds = totalTimeInSeconds;
                this.rotationsForEverySecond = rotationsForEverySecond;
            }
        }
    }
}


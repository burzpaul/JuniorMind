using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciclometru
{
    [TestClass]
    public class MyClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            double[] rotationInEverySecondAllCyclists = new double[] { 2,4,6,8,10, 2,10,6,9,5, 3,5,7,9,11 };
            var cyclist = new Cyclist[] { new Cyclist("Jeremy, Clarkson",10, GetRotationsForEverySecond(rotationInEverySecondAllCyclists,0,4))
                                          ,new Cyclist("James May",12,GetRotationsForEverySecond(rotationInEverySecondAllCyclists,5,9))
                                          ,new Cyclist("Richard Hammond",11,GetRotationsForEverySecond(rotationInEverySecondAllCyclists,10,14))};

            Assert.AreEqual(33.583, CalculateTotalDistance(cyclist),1);
            
        }
        private double CalculateTotalDistance(Cyclist[] cyclist)
        {
            double distance = 0;
            for (int i = 0; i < cyclist.Length; i++)
                for (int j = 0; j < cyclist[i].rotationsForEverySecond.Length; j++)
                    distance += cyclist[i].rotationsForEverySecond[j] * cyclist[i].diameterInCentimeters * Math.PI;
            return distance/100;
        }
        struct Cyclist
        {
            public string name;
            public double diameterInCentimeters;
            public double[] rotationsForEverySecond;
            public Cyclist(string name, double diameterInCentimeters, double[] rotationsForEverySecond)
            {
                this.name = name;
                this.diameterInCentimeters = diameterInCentimeters;
                this.rotationsForEverySecond = rotationsForEverySecond;
            }
        }
        private double[] GetRotationsForEverySecond(double[] rotationInEverySecondAllCyclists, int lowerBound, int upperBound)
        {
            double[] resultArray = new double[upperBound - lowerBound + 1];
            Array.Copy(rotationInEverySecondAllCyclists, lowerBound, resultArray, 0, resultArray.Length);
            return resultArray;
        }
        
        
    }
}


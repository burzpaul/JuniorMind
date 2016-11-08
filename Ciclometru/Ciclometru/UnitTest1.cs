using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciclometru
{
    [TestClass]
    public class MyClass
    {
        [TestMethod]
        public void TestMethods()
        {
            double[] rotationInEverySecondAllCyclists = new double[] { 2,4,6,8,10, 2,10,6,9,5, 3,5,11,9,7 };
            var cyclist = new Cyclist[] { new Cyclist("Jeremy, Clarkson",10, GetRotationsForEverySecond(rotationInEverySecondAllCyclists,0,4))
                                          ,new Cyclist("James May",12,GetRotationsForEverySecond(rotationInEverySecondAllCyclists,5,9))
                                          ,new Cyclist("Richard Hammond",11,GetRotationsForEverySecond(rotationInEverySecondAllCyclists,10,14))};

            Assert.AreEqual(33.583, CalculateTotalDistance(cyclist),1);
            Assert.AreEqual("Richard Hammond second 3", GetTopSpeedSecondAndCyclistName(cyclist));
            Assert.AreEqual("Richard Hammond", CyclistWithBestAverageSpeed(cyclist));
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
        private double CalculateTotalDistance(Cyclist[] cyclist)
        {
            double distance = 0;
            for (int i = 0; i < cyclist.Length; i++)
                distance += DistanceForOneCyclist(cyclist[i]);
            return distance / 100;
        }
        private string GetTopSpeedSecondAndCyclistName(Cyclist[] cyclist)
        {
            double holder = cyclist[0].rotationsForEverySecond.Max() * cyclist[0].diameterInCentimeters * Math.PI;
            int counter = 0;
            int second = 0;
            double maxRotations = 0;
            for (int i = 1; i < cyclist.Length; i++)
                if (holder < cyclist[i].rotationsForEverySecond.Max() * cyclist[i].diameterInCentimeters * Math.PI)
                {
                    holder = cyclist[i].rotationsForEverySecond.Max() * cyclist[i].diameterInCentimeters * Math.PI;
                    counter++;
                    maxRotations = cyclist[counter].rotationsForEverySecond.Max();
                }
            for (second = 0; second < cyclist[counter].rotationsForEverySecond.Length; second++)
                if (maxRotations == cyclist[counter].rotationsForEverySecond[second])
                    break;
            return cyclist[counter].name +" second " + (second+1);
        }
        private string CyclistWithBestAverageSpeed(Cyclist[] cyclist)
        {
            double averageSpeed = 0;
            int counter = -1;
            double distance = 0;
            for (int i = 0; i < cyclist.Length; i++)
            {
                distance = DistanceForOneCyclist(cyclist[i]);
                if (averageSpeed < distance)
                {
                    averageSpeed = distance / (cyclist[i].rotationsForEverySecond.Length + 1);
                    counter++;
                }
            }
            return cyclist[counter].name;
        }
        private static double DistanceForOneCyclist(Cyclist cyclist)
        {
            double distance = 0;
            for (int j = 0; j < cyclist.rotationsForEverySecond.Length; j++)
                distance += cyclist.rotationsForEverySecond[j] * cyclist.diameterInCentimeters * Math.PI;
            return distance;
        }
    }
}


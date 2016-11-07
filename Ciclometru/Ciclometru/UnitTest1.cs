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
            double[] rotationInEverySecondAllCyclists = new double[] { 2, 4, 6, 8, 10, 3, 5, 7, 9, 11, 2, 5, 6, 9, 10 };
            var cyclist = new Cyclist[] { new Cyclist("Jeremy, Clarkson",10, GetRotationsForEverySecond(rotationInEverySecondAllCyclists,0,4))
                                          ,new Cyclist("Richard Hammond",11,GetRotationsForEverySecond(rotationInEverySecondAllCyclists,5,9))
                                          ,new Cyclist("James May",12,GetRotationsForEverySecond(rotationInEverySecondAllCyclists,10,14))};
            Assert.AreEqual(33.583, CalculateTotalDistance(cyclist),1);
            Assert.AreEqual("James May second 5" , ReturnTopSpeedSecondAndCyclistsName(cyclist));
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
        };
        struct TopSpeedCyclist
        {
            public string name;
            public int second;
           
            public TopSpeedCyclist(string name , int second, double speed)
            {
                this.name = name;
                this.second = second;
            }
        }
        TopSpeedCyclist getCyclist;
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
                distance += CalculateDistanceForCyclist(cyclist[i]);
            return distance/100;
        }
        private double CalculateDistanceForCyclist(Cyclist cyclist)
        {
            double circumference = Math.PI * cyclist.diameterInCentimeters;
            double distance = 0;
            for (int i = 0; i < cyclist.rotationsForEverySecond.Length; i++)
                distance += cyclist.rotationsForEverySecond[i] * circumference;
            return distance;
        }
        private string ReturnTopSpeedSecondAndCyclistsName(Cyclist[] cyclist)
        {
            
            double topSpeed = 0;
            for (int i = 0; i < cyclist.Length; i++)
                if (topSpeed < GetTopSpeedForCyclist(cyclist[i]))
                    topSpeed = GetTopSpeedForCyclist(cyclist[i]);
            return getCyclist.name + " second " + getCyclist.second  ;
        }
        private double GetTopSpeedForCyclist(Cyclist cyclist)
        {
            double circumference = Math.PI * cyclist.diameterInCentimeters;
            double holder = 0;
            int second = 0;
            for (int i = 0; i < cyclist.rotationsForEverySecond.Length; i++)
                if (holder < (circumference * cyclist.rotationsForEverySecond[i]))
                {
                    holder = circumference * cyclist.rotationsForEverySecond[i];
                    second = i + 1;
                }
            getCyclist.name = cyclist.name;
            getCyclist.second = second;
            return holder;
        }
    }
}


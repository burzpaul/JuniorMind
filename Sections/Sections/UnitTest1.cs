using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sections
{
    [TestClass]
    public class MyClass
    {
        [TestMethod]
        public void Intersection1()
        {
            Assert.AreEqual(new Point(1, 0), FindFirstIntersectionPoint(new Point(0, 0), new Directions[] { Directions.right, Directions.right, Directions.up, Directions.left, Directions.down }));
        }
        [TestMethod]
        public void Intersection2()
        {
            Assert.AreEqual(new Point(4, 4), FindFirstIntersectionPoint(new Point(2, 2), new Directions[] {Directions.up,Directions.right,Directions.up,Directions.right,Directions.right,Directions.down,Directions.right,Directions.down,Directions.left,Directions.left,Directions.up,Directions.up,Directions.up}));
        }
        [TestMethod]
        public void Intersection3()
        {
            Assert.AreEqual(new Point(-2, 2), FindFirstIntersectionPoint(new Point(0, 4), new Directions[] { Directions.left,Directions.down,Directions.left,Directions.down,Directions.down,Directions.down,Directions.right,Directions.right,Directions.right,Directions.right,Directions.up,Directions.up,Directions.left,Directions.left,Directions.left,Directions.left,Directions.left,Directions.left }));
        }
        public enum Directions
        {
            up,
            down,
            left,
            right
        }
        struct Point
        {
            public double x;
            public double y;
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public void GetDirections(Directions direction,int length)
            {
                if (direction == Directions.up) y += length;
                if (direction == Directions.down) y -= length;
                if (direction == Directions.right) x += length;
                if (direction == Directions.left) x -= length;
            }
        }
        private Point FindFirstIntersectionPoint(Point point, Directions[] directions)
        {
            Point[] storedPoints = new Point[directions.Length];
            for(int i=0;i<directions.Length;i++)
            {
                point.GetDirections(directions[i], 1);
                        storedPoints[i] = point;    
            }
            for (int k = 0; k < storedPoints.Length; k++)
            {
                if (CheckIntersection(storedPoints[k], storedPoints,k+1))
                    return storedPoints[k];
            }
            return new Point(0, 0);
        }
        private bool CheckIntersection(Point point, Point[] storedPoints,int position)
        {
            for (int i = position; i < storedPoints.Length; i++) 
            {
                if (point.x == storedPoints[i].x && point.y == storedPoints[i].y)
                    return true;
            }
            return false;
        }
    }
}

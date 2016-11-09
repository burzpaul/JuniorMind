using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sections
{
    [TestClass]
    public class MyClass
    {
        [TestMethod]
        public void Intersection()
        {
            Assert.AreEqual(new Point(1,0),FindFirstIntersectionPoint(new Point(0, 0),new Directions[] {Directions.right,Directions.right,Directions.up,Directions.left,Directions.down}));
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
                if (CheckIntersection(point, storedPoints))
                    return point;
            }
            return new Point(0, 0);
        }
        private bool CheckIntersection(Point point, Point[] storedPoints)
        {
            foreach(var p in storedPoints)
            {
                if (point.x == p.x && point.y == p.y)
                    return true;
            }
            return false;
        }
    }
}

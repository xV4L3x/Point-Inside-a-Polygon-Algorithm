using System;
using System.Collections.Generic;
using System.Linq;
namespace Math_Algorithms
{
    class Program
    {
        class Point
        {
            public double x;
            public double y;
        }

        //List of points
        static List<Point> Points = new List<Point> { new Point { x = 1, y = 1 }, new Point { x = 5, y = 1 }, new Point { x = 3, y = 4 } };

        static Point Punto = new Point {x=0, y=10 };
        static void Main(string[] args)
        {
            int intersectionsCount = 0;
            for (int i = 0; i <= Points.Count - 1; i++)
            {
                int j = i + 1;
                //Avoid to handle last point otherwise the cycle will crash
                if (Points.ElementAtOrDefault(j) == null)
                {
                    j = 0;
                }

                //Angular coefficient of the line
                var m = (Points[j].y - Points[i].y) / (Points[j].x - Points[i].x);
                //m of the ray is = 0

                //q value of the line
                var qSegment = (-m * Points[i].x) + Points[i].y;
                //q value of the ray
                var qPointRay = Punto.y;


                //Get bigger and smaller x and y values to determine if the point is inside the segment
                double biggerX = (Points[i].x - Points[j].x) >= 0 ? Points[i].x : Points[j].x;
                double biggerY = (Points[i].y - Points[j].y) >= 0 ? Points[i].y : Points[j].y;
                double smallerX = (Points[i].x - Points[j].x) >= 0 ? Points[j].x : Points[i].x;
                double smallerY = (Points[i].y - Points[j].y) >= 0 ? Points[j].y : Points[i].y;

                //Check if point is on the line created by the segment
                if (m*Punto.x + qSegment - Punto.y == 0)
                {
                    //Check if the point is in the segment
                    if (Punto.x <= biggerX && Punto.x >= smallerX && Punto.y <= biggerY && Punto.y >= smallerY)
                    {
                        //Set intersections to an odd value to make the machine think the point is in
                        intersectionsCount = 1;
                        break;
                    }
                }

                //This goes here bcause if it goes up it breaks the cycle when the point is on a line parallele to x axis
                if (m == 0)
                {
                    //No intersections, cause the lines are parallele
                    continue;
                }

                //Get the x value of the intersection point
                var intersectionX = (qPointRay - qSegment) / m;

                //Get the y value of the intersection point
                var intersectionY = m * intersectionX + qSegment;

                Point intersectionPoint = new Point { x = intersectionX, y = intersectionY };

                if (intersectionPoint.x <= biggerX && intersectionPoint.x >= smallerX && intersectionPoint.y <= biggerY && intersectionPoint.y >= smallerY && intersectionPoint.x >= Punto.x)
                {
                    //Ray collides with the segment
                    intersectionsCount++;
                } 
            }
            Console.WriteLine(intersectionsCount);
            if (intersectionsCount % 2 == 0)
            {
                Console.WriteLine("Point is out");
            }
            else
            {
                Console.WriteLine("Point is INNN");
            }
        }
    }
}

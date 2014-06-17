/* Write an expression that checks for given point (x, y) if it is within the circle 
 * K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2). */

using System;

namespace _06.PointInsideCircle
{
    class CheckPoint
    {
        static void Main()
        {
            Console.Write("Enter X coordinate of point : ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter Y coordinate of point : ");
            double y = double.Parse(Console.ReadLine());

            // Circle radius = 3, center is on coords (1,1) If dX^2 + dY^2 < R -> point is inside circle.
            bool isInCircle = (x-1) * (x-1) + (y-1) * (y-1) < (3*3);

            // Rectangle edges is on (1,-1), (7,1). Point is inside rect if 1 < X < 7 and -1 < Y < 1
            bool isInRectange = ((x > -1) && (x < 5) && (y > 1) && (y < 3));

            // Point is a solution if it is inside circle and NOT inside rectangle.
            Console.WriteLine("Point {0},{1} is solution? {2}", x, y, isInCircle && !isInRectange);
        }
    }
}

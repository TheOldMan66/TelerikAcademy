/* Write an expression that checks if given point (x,  y) is within a circle K(O, 5). */

using System;

namespace _06.PointInsideCircle
{
    class PointInsideCircle
    {
        static void Main()
        {
            Console.Write("Enter X coordinate of point : ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter Y coordinate of point : ");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Point {0},{1} is inside circle? {2}", x, y, x * x + y * y < 25.0);
        }
    }
}

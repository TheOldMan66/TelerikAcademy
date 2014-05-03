/* Write a program that reads the radius r of a circle and prints its perimeter and area. */

using System;

namespace _02.PrintPerimeterAndAreaOfCircle
{
    class CircleProperties
    {
        static void Main(string[] args)
        {
            double radius = 0.0d;
            bool correctInput = false;
            do
            {
                Console.Write("Enter circle radius: ");
                correctInput = double.TryParse(Console.ReadLine(), out radius) & (radius >= 0.0d);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);
            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * radius * radius;
            Console.WriteLine("Circle with radius {0} have perimeter {1} and area {2}", radius, perimeter, area);
        }
    }
}

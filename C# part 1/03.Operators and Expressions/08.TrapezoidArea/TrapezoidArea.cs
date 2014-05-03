/* Write an expression that calculates trapezoid's area by given sides a and b and height h. */

using System;

namespace _08.TrapezoidArea
{
    class TrapezoidArea
    {
        static void Main()
        {
            Console.Write("Enter a trapezoid upper side: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter a trapezoid lower side: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter a trapezoid height: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Trapezoid’s area is {0}", (sideA + sideB) / 2 * height);
        }
    }
}

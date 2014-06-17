/* Write a program that reads the coefficients a, b and c of a quadratic 
 * equation ax2+bx+c=0 and solves it (prints its real roots). */

using System;
using System.Threading;
using System.Globalization;

namespace _06.QuadraticEquationSolver
{
    class QuadraticEquationSolver
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            bool correctInput = false;
            double a = 0d;
            double b = 0d;
            double c = 0d;

            Console.WriteLine("Solver for equation a*x*x + b*x + c = 0");
            do
            {
                Console.Write("Enter coefficient a: ");
                correctInput = double.TryParse(Console.ReadLine(), out a);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);
            do
            {
                Console.Write("Enter coefficient b: ");
                correctInput = double.TryParse(Console.ReadLine(), out b);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);
            do
            {
                Console.Write("Enter coefficient c: ");
                correctInput = double.TryParse(Console.ReadLine(), out c);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);

            double discr = b * b - (4 * a * c);
            if (discr < 0.0d)
            {
                Console.WriteLine("Equation has no real roots.");
            }
            else
            {
                Console.WriteLine("Root 1 = {0}", (-b + Math.Sqrt(discr)) / (2 * a));
                Console.WriteLine("Root 2 = {0}", (-b - Math.Sqrt(discr)) / (2 * a));

            }
        }
    }
}



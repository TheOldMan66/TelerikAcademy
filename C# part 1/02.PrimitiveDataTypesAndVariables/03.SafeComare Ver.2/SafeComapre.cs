/* Write a program that safely compares floating-point numbers with precision of 0.000001
 * This version use decimal data type and can handle various precision */

using System;

namespace SafeCompare
{
    class SafeCompare
    {
        static void Main()
        {
            decimal precision = 0.000001m;
            decimal firstFloat;
            decimal secondFloat;
            bool isNumber;
            do
            {
                Console.Write("Enter first floating-point number to compare : ");
                isNumber = decimal.TryParse(Console.ReadLine(), out firstFloat);
                if (!isNumber) Console.WriteLine("Incorrect input. Try again.\n");
            } while (!isNumber);
            do
            {
                Console.Write("Enter second floating-point number to compare: ");
                isNumber = decimal.TryParse(Console.ReadLine(), out secondFloat);
                if (!isNumber) Console.WriteLine("\nIncorrect input. Try again.");
            } while (!isNumber);
            if (Math.Abs(firstFloat - secondFloat) < precision)
            {
                Console.WriteLine("These numbers are EQUAL with precision {0}", precision);
            }
            else
            {
                Console.WriteLine("These numbers are DIFFERENT with precision {0}", precision);
            }
        }
    }
}

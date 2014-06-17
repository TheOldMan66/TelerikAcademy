/* Write a program that calculates the greatest common divisor (GCD) of given two numbers. 
 * Use the Euclidean algorithm (find it in Internet). */
using System;

namespace _08.FindGCD
{
    class FindGCD
    {
        static void Main()
        {
            Console.Write("Enter first integer : ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer : ");
            int second = int.Parse(Console.ReadLine());
            int reminder;
            Console.Write("\nGCD of {0} and {1} is ", first, second);
            do
            {
                reminder = first % second;
                first = second;
                second = reminder;
            } while (reminder != 0);
            Console.WriteLine(first);
            Console.WriteLine();
        }
    }
}

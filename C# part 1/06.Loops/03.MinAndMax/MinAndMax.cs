/* Write a program that reads from the console a sequence of N integer
 * numbers and returns the minimal and maximal of them. */

using System;

namespace _03.MinAndMax
{
    class MinAndMax
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} value : ");
                int input = int.Parse(Console.ReadLine());
                if (input < min) { min = input; }
                if (input > max) { max = input; }
            }
            Console.WriteLine("Min value is {0} and max value is {1}.", min, max);
        }
    }
}

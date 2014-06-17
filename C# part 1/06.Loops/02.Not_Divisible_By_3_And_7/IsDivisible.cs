/* Write a program that prints all the numbers from 1 to N, 
 * that are not divisible by 3 and 7 at the same time. */

using System;

namespace _02.Not_Divisible_By_3_And_7
{
    class IsDivisible
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\nVariant 1:");
            for (int i = 1; i <= n; i++)
            {
                if ((i % 3 != 0) || (i % 7 != 0))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\n\nVariant 2:");
            for (int i = 1; i <= n; i++)
            {
                if (i % (3*7) != 0) 
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
/* Write a program to print the first 100 members of the sequence of Fibonacci: 
 * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, … */

using System;

namespace _09.FibonacciSequence
{
    class FibonacciSequence
    {
        static void Main()
        {
            decimal f1 = 0;
            decimal f2 = 1;
            decimal f3 = 0;
            Console.WriteLine("  1 -> {0,24}", f1);
            Console.WriteLine("  2 -> {0,24}", f2); 
            for (int i = 2; i < 100; i++)
            {
                f3 = f1 + f2;
                Console.WriteLine("{0,3} -> {1,24}", i+1, f3);
                f1 = f2;
                f2 = f3;
            }
        }
    }
}

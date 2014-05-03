/* Write a program that reads a number N and calculates the sum of the first N members 
 * of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
 * Each member of the Fibonacci sequence (except the first two) is a sum of the previous 
 * two members. */

using System;
using System.Numerics;

namespace _07.SumOfFibonacciNumbers
{
    class SumOfFibonacci
    {
        static void Main()
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            BigInteger f1 = 0;
            BigInteger f2 = 1;
            BigInteger f3 = 0;
            BigInteger sum = 0;
            for (int i = 2; i <= n; i++)
            {
                f3 = f1 + f2;
                sum = sum + f3;
                f1 = f2;
                f2 = f3;
            }
            Console.WriteLine("\nSum of first {0} members of Fibonacci sequence is {1}\n", n, sum);
        }
    }
}

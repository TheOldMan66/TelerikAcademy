/* Write a program that, for a given two integer numbers N and X, calculates the sum
S = 1 + 1!/X + 2!/X2 + … + N!/XN */

using System;

namespace _06.NFactDivXPowN
{
    class NFactDivXPowN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter value for X : ");
            int x = int.Parse(Console.ReadLine());
            double result = 1;
            double factorial = 1;
            double xpow = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
                xpow = xpow * x;
                result = result + factorial/xpow;
            }
            Console.WriteLine(result);
        }
    }
}

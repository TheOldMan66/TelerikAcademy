/* In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
 *(formula is too complex to rewrite it here :) )
 * Write a program to calculate the Nth Catalan number by given N. */

using System;
using System.Numerics;

namespace _09.CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main()
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            BigInteger factorialX2 = 2;
            for (int i = 2; i <= n; i++)
            {
                factorial = factorial * i; // calculate n!
                factorialX2 = factorialX2 * ((2 * i) - 1) * (2 * i); //calculate 2n!
            }
            BigInteger catalan = factorialX2 / (factorial * (n + 1) * factorial); //catalan = 2n!/(n!*(n+1)*n!)
            Console.WriteLine("\nCatalan number for {0} is {1}", n, catalan);
        }
    }
}

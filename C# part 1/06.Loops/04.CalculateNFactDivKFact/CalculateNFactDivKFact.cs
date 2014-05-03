/* Write a program that calculates N!/K! for given N and K (1<K<N). */

using System;
using System.Numerics;

namespace _04.CalculateNFactDivKFact
{
    class CalculateNFactDivKFact
    {
        static void Main()
        {
            /* N!/K! = 1/1 * 2/2 * 3/3 * ... * K/K * (K+1) * (K+2) * .... * N = (N-(K+1))! */
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter value for K : ");
            int k = int.Parse(Console.ReadLine());
            BigInteger result = k + 1;
            for (int i = k+2; i <= n; i++)
            {
                result = result * i;                
            }
            Console.WriteLine("{0}!/{1}! = {2}", n, k, result);
        }
    }
}

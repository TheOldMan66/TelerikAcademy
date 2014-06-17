/* Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K). */

using System;
using System.Numerics;

namespace _05.AnotherFactorial

{
    class AnotherFactorial
    {
        static void Main()
        {
            /* N!*K! / (K-N)! = (1*1/1)*(2*2/2)* ... * (N*N/N)* ((N+1)(N+1)* ... *(K*K) */
            Console.Write("Enter value for K : ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i = 1; i <= k; i++)
            {
                result = result * i;
                if (i <= n) { result = result * i; }
                if (i <= (k - n)) { result = result / i; }
            }
            Console.WriteLine("\n{0}!*{1}!/({0}-{1})! = {2}\n", k, n, result);
        }
    }
}

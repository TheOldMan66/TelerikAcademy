/* Write an expression that checks if given positive integer 
 * number n (n ≤ 100) is prime. E.g. 37 is prime */

using System;

namespace _07.PrimeNumber
{
    class PrimeNumber
    {
        static void Main()
        {
            Console.Write("Enter a positive integer: ");
            int value = int.Parse(Console.ReadLine());
            bool isPrime = (value < 3) | (value % 2 != 0);
            if (isPrime)
            {
                for (int i = 3; i <= Math.Sqrt(value); i = i + 2)
                {
                    if (value % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }                
            }
            Console.WriteLine("Number {0} is prime? {1} ", value, isPrime);
        }
    }
}


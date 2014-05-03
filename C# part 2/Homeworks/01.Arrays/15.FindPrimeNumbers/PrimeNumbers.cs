using System;

class PrimeNumbers
{
    static void Main()
    {

        /* Write a program that finds all prime numbers in the range [1...10 000 000]. 
         * Use the sieve of Eratosthenes algorithm (find it in Wikipedia). */

        bool[] isComplex = new bool[10000000];
        for (int i = 2; i < 10000000; i++)
        {
            if (!isComplex[i])
            {
                Console.Write(" {0},",i);
                int j = i;
                do
                {
                    isComplex[j] = true;
                    j = j + i;
                } while (j < 10000000);
            }
        }
    }
}
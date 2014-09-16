using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Divisors
{
    // ufff... so huge :) I can't find proper place to use 
    // my lovely low quality program code patterns :)
    class Divisors
    {
        // i can use List<int> to keep remaining digits, but i'm affraid that will be too slow.
        private static bool[] used = new bool[5];
        private static int[] digits = new int[5];
        private static int minDivisor = int.MaxValue;
        private static int numberWithMinDivisors = 0;
        private static int n;

        private static void GetNumOfDivisors(int num)
        {
            int countOfDivisors = 0;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    countOfDivisors++;
                }
            }

            if (countOfDivisors < minDivisor)
            {
                minDivisor = countOfDivisors;
                numberWithMinDivisors = num;
            }
            else if (countOfDivisors == minDivisor)
            {
                if (num < numberWithMinDivisors)
                {
                    numberWithMinDivisors = num;
                }
            }
        }

        private static void Recursion(int number, int depth)
        {
            if (depth == n)
            {
                GetNumOfDivisors(number);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    Recursion(number * 10 + digits[i], depth + 1);
                    used[i] = false;
                }
            }
        }

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            Recursion(0, 0);
            Console.WriteLine(numberWithMinDivisors);
        }
    }
}

// BgCoder: 100 / 100	Памет: 8.78 MB Време: 0.052 s
//Sorry, no time for more jokes. Have nice day (or may be night?) and good luck on next exam.

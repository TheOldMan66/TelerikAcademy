/* Write a program that prints all the numbers from 1 to N. */

namespace _01.Loop_From_1_To_N
{
    using System;
    class LoopToN
    {
        static void Main()
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}

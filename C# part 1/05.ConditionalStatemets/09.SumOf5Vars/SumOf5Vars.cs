/* We are given 5 integer numbers. Write a program that checks if the 
 * sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0. */

using System;

namespace _09.SumOf5Vars
{
    class SumOf5Vars
    {
        static void Main()
        {
            int [] inputValues = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter value for variable {0} : ", i+1);
                inputValues[i] = int.Parse(Console.ReadLine());
            }
            int sum = 0;
            for (byte i = 1; i < 32; i++)
            {
                sum = 0;
                for (byte j = 0; j < 5; j++)
                {
                    if ((i & (1<<j)) != 0)
                    {
                        sum = sum + inputValues[j];
                    }
                }
                if (sum == 0)
                {
                    for (byte j = 0; j < 5; j++)
                    {
                        if ((i & (1 << j)) != 0)
                        {
                            Console.Write(inputValues[j] + " ");
                        }
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}

/* Write a program that reads from the console a positive integer number N (N < 20) 
 * and outputs a matrix like the following 
 *          1   2   3
 *          2   3   4
 *          3   4   5 */

using System;

namespace _11.ShiftedMatrix
{
    class ShiftedMatrix
    {
        static void Main()
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            string divider = "+";
            for (int i = 0; i < n; i++)
            {
                divider = divider + "--+";
            }
            Console.WriteLine(divider);
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n + i; j++)
                {
                    Console.Write("|{0,2}",(j + 1));
                }
                Console.WriteLine("|");
                Console.WriteLine(divider);
            }
        }
    }
}

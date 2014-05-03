/* Write a program that reads an integer number n from the console and prints 
 * all the numbers in the interval [1..n], each on a single line. */

using System;
using System.Threading;
using System.Globalization;


namespace _08.PrintSequence
{
    class PrintSequence
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            bool correctInput = false;
            int n = 0;

            do
            {
                Console.Write("Enter number of digits: ");
                correctInput = int.TryParse(Console.ReadLine(), out n);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);

            for (int i = 0; i < n; i++)
                    Console.WriteLine(i + 1);
        }
    }
}

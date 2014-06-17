/* Write a program that gets a number n and after that gets more n numbers 
 * and calculates and prints their sum. */

using System;
using System.Threading;
using System.Globalization;


namespace _07.CalculateSumOfNNumbers
{
    class CalculateSumOfNNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            bool correctInput = false;
            int n = 0;
            double sum = 0d;
            double value = 0d;

            do
            {
                Console.Write("Enter number of digits: ");
                correctInput = int.TryParse(Console.ReadLine(), out n);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);

            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Enter number {0}: ", i+1);
                    correctInput = double.TryParse(Console.ReadLine(), out value);
                    if (!correctInput)
                        Console.WriteLine("Incorrect input. Try again.");
                } while (!correctInput);
                sum = sum + value;
            }
         Console.WriteLine("\nSum is {0}\n", sum);
        }
    }
}

/* Write a program that gets two numbers from the console and 
 * prints the greater of them. Don’t use if statements. */

using System;
using System.Threading;
using System.Globalization;

namespace _05.FindGreaterNumber
{
    class FindGretaer
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            bool correctInput = false;
            decimal startDecimal = 0M;
            decimal endDecimal = 0M;
            do
            {
                Console.Write("Enter first integer: ");
                correctInput = decimal.TryParse(Console.ReadLine(), out startDecimal);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);
            do
            {
                Console.Write("Enter second integer: ");
                correctInput = decimal.TryParse(Console.ReadLine(), out endDecimal);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);
            Console.WriteLine("Greater number of {0} and {1} is {2}", startDecimal, endDecimal, 
                (startDecimal + endDecimal+ Math.Abs(startDecimal - endDecimal)) / 2);
        }
    }
}



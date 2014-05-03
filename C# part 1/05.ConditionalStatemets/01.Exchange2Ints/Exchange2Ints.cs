/* Write an if statement that examines two integer variables and exchanges their values
 * if the first one is greater than the second one. */

using System;

namespace _01.Exchange2Ints
{
    class Exchange2Ints
    {
        static void Main()
        {
            Console.Write("Enter first integer: ");
            int firstInt = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int secondInt = int.Parse(Console.ReadLine());
            if (firstInt > secondInt)
            {
                int swap = firstInt;
                firstInt = secondInt;
                secondInt = swap;
                Console.WriteLine("Changing values. Now first is {0}, second is {1}", firstInt,secondInt);
            }
            else
            {
                Console.WriteLine("Values unchanged. First is {0}, second is {1}", firstInt, secondInt);
            }
        }
    }
}

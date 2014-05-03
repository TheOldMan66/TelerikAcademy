/* Write a program that reads two positive integer numbers and prints 
 * how many numbers p exist between them such that the reminder of the 
 * division by 5 is 0 (inclusive). Example: p(17,25) = 2. */

using System;

namespace _04.FindIntsDividedBy5
{
    class FindSomeInts
    {
        static void Main()
        {
            uint startInt = 0u;
            uint endInt = 0u;
            bool correctInput = false;
            do
            {
                do
                {
                    Console.Write("Enter first integer (0 for exit): ");
                    correctInput = uint.TryParse(Console.ReadLine(), out startInt);
                    if (!correctInput)
                        Console.WriteLine("Incorrect input. Try again.");
                } while (!correctInput);
                if (startInt == 0u) return;
                do
                {
                    Console.Write("Enter second integer: ");
                    correctInput = uint.TryParse(Console.ReadLine(), out endInt);
                    if (!correctInput)
                        Console.WriteLine("Incorrect input. Try again.");
                } while (!correctInput);
                if (startInt == 0)
                {
                    Console.Write((endInt / 5) + 1);
                }
                else
                {
                    Console.Write((endInt / 5) - (startInt - 1) / 5);
                }
                Console.WriteLine(" numbers in range {0} - {1} can be divided by 5 w/o remainder.", startInt, endInt);
            } while (startInt != 0u);
        }
    }
}

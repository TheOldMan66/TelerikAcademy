/* Write a program that reads 3 integer numbers from the console and prints their sum. */

using System;

namespace _01.ReadAndPrint3Ints
{
    class ReadAndPrint3Ints
    {
        static void Main()
        {
            int firstInt = 0;
            int secondInt = 0;
            int thirdInt = 0;
            bool correctInput = false;
            do
            {
                Console.Write("Enter first integer: ");
                correctInput = int.TryParse(Console.ReadLine(), out firstInt);
                if (!correctInput) 
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);

            do
            {
                Console.Write("Enter second integer: ");
                correctInput = int.TryParse(Console.ReadLine(), out secondInt);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);

            do
            {
                Console.Write("Enter third integer: ");
                correctInput = int.TryParse(Console.ReadLine(), out thirdInt);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);

            Console.WriteLine("{0} + {1} + {2} = {3}", firstInt, secondInt, thirdInt, firstInt + secondInt + thirdInt);
        }
    }
}

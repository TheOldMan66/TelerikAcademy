/* Write a program that finds the biggest of three integers using nested if statements. */

using System;


namespace _03.BiggestOfThreeInts
{
    class BiggestOfThree
    {
        static void Main()
        {
            Console.Write("Enter first integer: ");
            int firstInt = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int secondInt = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int thirdInt = int.Parse(Console.ReadLine());
            if (firstInt > secondInt)
            {
                if (firstInt > thirdInt)
                {
                    Console.WriteLine("First number is biggest");                    
                }
                else
                {
                    Console.WriteLine("Third number is biggest");                    
                }
            }
            else
            {
                if (secondInt > thirdInt)
                {
                    Console.WriteLine("Second number is biggest");
                }
                else
                {
                    Console.WriteLine("Third number is biggest");
                }

            }
        }
    }
}

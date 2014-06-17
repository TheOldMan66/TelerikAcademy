/* Write a program that finds the greatest of given 5 variables. */

using System;

namespace _07.GreatestOf5Vars
{
    class FindGreatest
    {
        static void Main()
        {
            double inputValue;
            double greatest = double.MinValue;
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter value for variable {0} : ",i);
                inputValue = double.Parse(Console.ReadLine());
                if (inputValue > greatest) {greatest = inputValue;}
            }
            Console.WriteLine("Greatest value is {0}.", greatest);
        }
    }
}

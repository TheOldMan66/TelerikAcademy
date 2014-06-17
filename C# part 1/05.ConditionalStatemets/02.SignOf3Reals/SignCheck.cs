/* Write a program that shows the sign (+ or -) of the product of three real numbers 
 * without calculating it. Use a sequence of if statements. */

using System;


namespace _02.SignOf3Reals
{
    class SignCheck
    {
        static void Main()
        {
            Console.Write("Enter first number: ");
            double firstNum = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double secondNum = double.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            double thirdNum = double.Parse(Console.ReadLine());
            if ((firstNum == 0.0d) || (secondNum == 0.0d) || (thirdNum == 0.0d))
            {
                Console.WriteLine("Product of {0}, {1} and {2} is zero", firstNum, secondNum, thirdNum);
            }
            else
            {
                byte signCount = 0;
                if (firstNum < 0.0d)
                {
                    signCount++;
                }
                if (secondNum < 0.0d)
                {
                    signCount++;
                }
                if (thirdNum < 0.0d)
                {
                    signCount++;
                }
                if ((signCount == 1) || (signCount == 3))
                {
                    Console.WriteLine("Sign of product of {0}, {1} and {2} is negative", firstNum, secondNum, thirdNum);
                }
                else
                {
                    Console.WriteLine("Sign of product of {0}, {1} and {2} is positive", firstNum, secondNum, thirdNum);
                }
            }

        }
    }
}

/* Write a program that safely compares floating-point numbers with precision of 0.000001
 * This version use weakness of float data type, but work only with numbers < 10 */

using System;

namespace SafeCompare
{
    class SafeCompare
    {
        static void Main()
        {
            float firstFloat;
            float secondFloat;
            bool isNumber;
            do
            {
                Console.Write("Enter first floating-point number to compare : ");
                isNumber = float.TryParse(Console.ReadLine(), out firstFloat);
                if (!isNumber) Console.WriteLine("Incorrect input. Try again.\n");
            } while (!isNumber);
            do
            {
                Console.Write("Enter second floating-point number to compare: ");
                isNumber = float.TryParse(Console.ReadLine(), out secondFloat);
                if (!isNumber) Console.WriteLine("\nIncorrect input. Try again.");
            } while (!isNumber);
            if (firstFloat == secondFloat)
            {
                Console.WriteLine("These numbers are equals when using float type");
            }
            else
            {
                Console.WriteLine("These numbers are different when using float type");
            }
        }
    }
}

using System;

/* Write a program that reads an integer number and calculates and prints its square root. 
 * If the number is invalid or negative, print "Invalid number". In all cases finally 
 * print "Good bye". Use try-catch-finally */

namespace _01.SquareRoot
{
    class SqareRoot
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter a integer number: ");
                int input = int.Parse(Console.ReadLine());
                if (input < 0)
                    throw new ArgumentOutOfRangeException();
                double root = Math.Sqrt(input);
                Console.WriteLine("Square root is {0}.", root);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("End of input (Ctrl-Z) detected.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Cannot calculate square root of negative number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input number is too big or too small for int data type");
            }
            catch (FormatException)
            {
                Console.WriteLine("Data entered is not a integer number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}

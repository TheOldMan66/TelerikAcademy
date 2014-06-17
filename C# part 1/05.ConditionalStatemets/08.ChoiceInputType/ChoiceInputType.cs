/* Write a program that, depending on the user's choice inputs int, double or string variable. 
 * If the variable is integer or double, increases it with 1. If the variable is string, 
 * appends "*" at its end. The program must show the value of that variable as a console output. 
 * Use switch statement. */

using System;

namespace _08.ChoiceInputType
{
    class ChoiceInputType
    {
        static void Main()
        {
            Console.Write("Enter int, double or string value: ");
            string inputVar = Console.ReadLine();
            int intResult;
            double dblResult;
            if (int.TryParse(inputVar, out intResult))
            {
                Console.WriteLine("This value can be converted to int. New value (+1) is {0}", intResult + 1);
            }
            else
            {
                if (double.TryParse(inputVar, out dblResult))
                {
                    Console.WriteLine("This value can not be converted to int, but can fit in double.");
                    Console.WriteLine("New value (+1) is {0}", dblResult + 1.0d);
                }
                else
                {
                    Console.WriteLine("Input value cannot be converted to numeric type.");
                    Console.WriteLine("Adding \"*\" at the end and result is " + inputVar + "*" );
                }
            }
        }
    }
}

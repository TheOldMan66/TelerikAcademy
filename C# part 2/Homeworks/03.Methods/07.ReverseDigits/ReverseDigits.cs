using System;

class ReverseDigits
{
    static int Reverse(int input)
    {
        int output=0;
        while (input > 0)
        {
            output = output * 10 + input % 10;
            input = input / 10;
        }
        return output;
    }
    
    static void Main()
    {

        /* Write a method that reverses the digits of given decimal number. Example: 256  652 */

        Console.Write("Enter any positive integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Reversed number is {0}.",Reverse(number));
    }
}

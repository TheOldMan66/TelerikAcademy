using System;
using System.Text;

class DecToBin
{
    static void Main()
    {

        /* Write a program to convert decimal numbers to their binary representation. */

        Console.Write("Enter positive decimal number: ");
        int input = int.Parse(Console.ReadLine());
        StringBuilder s = new StringBuilder();
        Console.Write("Binary representation of {0} is ", input);
        while (input > 0)
        {
            s.Insert(0, input % 2); // insert '0' or '1' at beginning of string
            input = input / 2;
        }
        Console.WriteLine(s);
    }
}
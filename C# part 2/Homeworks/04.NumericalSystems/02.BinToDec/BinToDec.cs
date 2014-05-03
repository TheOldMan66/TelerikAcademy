using System;

class BinToDec
{
    static void Main()
    {

        /* Write a program to convert binary numbers to their decimal representation. */

        Console.Write("Enter unsigned binary number: ");
        string input = Console.ReadLine();
        int result = 0;
        for (int i = 0; i < input.Length; i++)
        {
            result = result * 2;
            if (input[i] == '1')
                result = result + 1;
        }
        Console.WriteLine("Decimal representation of {0} is {1}", input,result);
    }
}
using System;

/* Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
 * percentage and in scientific notation. Format the output aligned right in 15 symbols. */

class NumberFormats
{
    static void Main(string[] args)
    {
        bool correct = false;
        int input = 0;
        Console.Write("Enter integer number: ");
        while (!correct)
        {
            correct = int.TryParse(Console.ReadLine(), out input);
            if (!correct)
                Console.WriteLine("Incorrect input. Try again");
        }
        Console.WriteLine("Various formatting of this number:");
        Console.WriteLine("Decimal          :{0}",input.ToString().PadLeft(15));
        Console.WriteLine("Hexaecimal       :{0}", ("0x"+input.ToString("X")).PadLeft(15));
        Console.WriteLine("Percentage       :{0}", (input.ToString("P0")).PadLeft(15));
        Console.WriteLine("Scientific       :{0}", (input.ToString("E")).PadLeft(15));
    }
}
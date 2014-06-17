using System;
using System.Text;

class DecToHex
{
    static void Main()
    {

        /* Write a program to convert decimal numbers to their hexadecimal representation. */

        Console.Write("Enter positive decimal number: ");
        ulong input = ulong.Parse(Console.ReadLine());
        StringBuilder s = new StringBuilder();
        ulong inp = input;
        ulong tmp = 0; // for less writing only :)
        while (input > 0)
        {
            tmp = input % 16;
            if (tmp < 10)
                s.Insert(0, tmp);// value is 0..9
            else
                s.Insert(0, (char)(tmp + 55)); // value is A..F. Example: tmp = 11 -> (char)(11+55) = (char)66 = 'B'.
            input = input / 16;
        }
        Console.WriteLine("Binary representation of {0} is 0x{1}", inp, s);
    }
}
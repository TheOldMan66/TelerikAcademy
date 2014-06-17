using System;

/* Write a program that converts a string to a sequence of C# Unicode character literals. 
 * Use format strings. Sample input:
 * Hi!
 * Expected output:
 * \u0048\u0069\u0021
 */

class StringToUnicode
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
//        input = "سلطان";
        for (int i = 0; i < input.Length; i++)
        {
            Console.Write("\\u{0}",((int)input[i]).ToString("X4"));
        }
        Console.WriteLine();
    }
}
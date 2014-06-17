using System;
using System.Collections.Generic;

/* Write a program that reads a string from the console and replaces all series of consecutive 
 * identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa". */

class ConsecutiveLetters
{
    static void Main()
    {
        string input = "aaaaabbbbbcdddeeeedssaaaaaaabbbbbcdddeeeedssaa";
        Console.WriteLine("Input string is: {0}",input);
        char lastUsedChar = input[0];
        Console.WriteLine();
        Console.Write("Result is: ");
        Console.Write(lastUsedChar);
        for (int i = 1; i < input.Length; i++)
            if (input[i] != lastUsedChar)
            {
                lastUsedChar = input[i];
                Console.Write(lastUsedChar);
            }
        Console.WriteLine();
        Console.WriteLine();
    }
}
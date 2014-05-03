using System;

/* Write a program that reads from the console a string of maximum 20 characters. 
 * If the length of the string is less than 20, the rest of the characters should 
 * be filled with '*'. Print the result string into the console */

class FillStringTo20
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string s = Console.ReadLine();
        s = s.PadRight(20, '*');
        Console.WriteLine("String filled with '*' to 20 pos is: {0}",s);
    }
}
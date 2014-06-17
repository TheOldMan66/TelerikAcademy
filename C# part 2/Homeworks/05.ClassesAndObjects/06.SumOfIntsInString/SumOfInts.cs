/* You are given a sequence of positive integer values written into a string, 
 * separated by spaces. Write a function that reads these values from given 
 * string and calculates their sum. Example:
 * string = "43 68 9 23 318"  result = 461 */

using System;

class SumInt
{
    static int GetSum(string input)
    {
        int result = 0;
        string[] substrings = input.Split(new char[] {' '} , StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < substrings.Length; i++)
        {
            result = result + int.Parse(substrings[i]);
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter set of integers, divided by space: ");
        string input = Console.ReadLine();
//        string input = "212 111 131 56 97 14";
        Console.WriteLine("Sum of numbers is {0}", GetSum(input));
    }
}

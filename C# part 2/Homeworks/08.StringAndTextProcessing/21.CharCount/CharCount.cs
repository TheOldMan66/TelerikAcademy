using System;
using System.Collections.Generic;

/* Write a program that reads a string from the console and prints all different letters 
 * in the string along with information how many times each letter is found.  */

class CharCount
{
    static void Main(string[] args)
    {
        string input = StringConstants.submarine;
        Console.WriteLine("Input string:");
        Console.WriteLine(input);
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (dict.ContainsKey(input[i]))
                dict[input[i]]++;
            else
                dict.Add(input[i], 1);
        }
        Console.WriteLine();
        Console.WriteLine("Result: ");
        Console.WriteLine("Char   Count");
        foreach (KeyValuePair<char, int> element in dict)
        {
            Console.WriteLine(" '{0}' -> {1}", element.Key, element.Value);
        }
    }
}
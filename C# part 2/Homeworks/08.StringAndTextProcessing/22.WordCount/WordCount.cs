using System;
using System.Collections.Generic;

/* Write a program that reads a string from the console and lists all different words 
 * in the string along with information how many times each word is found. */

class WordCount
{
    static void Main(string[] args)
    {
        string input = StringConstants.submarine;
        string[] words = input.Split(new char[] { ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Input string:");
        Console.WriteLine(input);
        Dictionary<string, int> dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < words.Length; i++)
            if (dict.ContainsKey(words[i]))
                dict[words[i]]++;
            else
                dict.Add(words[i], 1);
        Console.WriteLine();
        Console.WriteLine("Result: ");
        Console.WriteLine("Word            Count");
        foreach (KeyValuePair<string, int> element in dict)
        {
            Console.WriteLine(" {0} -> {1}", element.Key.ToLower().PadRight(15), element.Value);
        }
    }
}

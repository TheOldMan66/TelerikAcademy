using System;
using System.Collections.Generic;

class Grisko
{
    static string input;
    static List<char> output = new List<char>();
    static HashSet<string> words = new HashSet<string>();
    static bool[] used;
    static int wordCount = 0;

    static void GenerateWord(int depth)
    {
        if (depth == 0)
        {
            string s = new string(output.ToArray());
            if (!words.Contains(s))
            {
                wordCount++;
                words.Add(s);
            }
            return;
        }
        int oc = output.Count;
        int il = input.Length;
        for (int i = 0; i < il; i++)
        {
            if (oc == 0 || (!used[i] && input[i] != output[oc - 1]))
            {
                output.Add(input[i]);
                used[i] = true;
                GenerateWord(depth-1);
                used[i] = false;
                output.RemoveAt(oc);
            }
        }
    }


    static void Main()
    {
        input = Console.ReadLine();
        used = new bool[input.Length];
        int recursionDepth = input.Length;
        GenerateWord(recursionDepth);
        Console.WriteLine(wordCount);
    }
}
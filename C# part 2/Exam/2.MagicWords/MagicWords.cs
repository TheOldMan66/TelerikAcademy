using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> input = new List<string>(n+1);
        int longestWord = 0;
        for (int i = 0; i < n; i++)
        {
            input.Add(Console.ReadLine());
            if (input[i].Length > longestWord) longestWord = input[i].Length;
        }
        int newPos = 0;
        for (int i = 0; i < n; i++)
        {
            newPos = (input[i].Length % (n + 1));
            input.Insert(newPos, input[i]);
            if (newPos < i)
                input.RemoveAt(i + 1);
            else
                input.RemoveAt(i);
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < longestWord; i++)
            for (int j = 0; j < n; j++)
                if (i < input[j].Length) sb.Append(input[j][i]);
        Console.WriteLine(sb);
    }
}
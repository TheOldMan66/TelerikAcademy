using System;
using System.Collections.Generic;
using System.Text;


class ConsoleJustification
{
    static void Main()
    {
        string s;
        int inputLines = int.Parse(Console.ReadLine());
        int desiredWidth = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < inputLines; i++)
        {
            s = Console.ReadLine();
            sb.Append(s.Trim() + " ");
        }
        sb.Remove(sb.Length - 1, 1);
        string[] sWords = sb.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> words = new List<string>(sWords);
        do
        {

            sb.Clear();
            sb.Append(words[0]);
            int currentWord = 1;
            while (sb.Length < desiredWidth && currentWord < words.Count)
            {
                sb.Append(" " + words[currentWord]);
                currentWord++;
            }
            if (sb.Length > desiredWidth)
            {
                sb.Remove(sb.Length - words[currentWord - 1].Length - 1, words[currentWord - 1].Length + 1);
                currentWord--;
            }
                if (sb.Length == desiredWidth || currentWord == 1)
            {
                Console.WriteLine(sb);
                words.RemoveRange(0, currentWord);
                continue;
            }
            int spacecount = currentWord - 1;
            int sizeOfSpaces = (desiredWidth - sb.Length + spacecount) / spacecount; // / (currentWord - 1)
            int numOfLongSpaces = (desiredWidth - sb.Length + spacecount) % spacecount;
            sb.Clear();
            sb.Append(words[0]);
            for (int i = 1; i <= spacecount; i++)
            {
                if (i <= numOfLongSpaces)
                    sb.Append(" ");
                sb.Append(new string(' ',sizeOfSpaces) + words[i]);
            }
            Console.WriteLine(sb);
            words.RemoveRange(0, currentWord);
        } while (words.Count > 0);
    }
}
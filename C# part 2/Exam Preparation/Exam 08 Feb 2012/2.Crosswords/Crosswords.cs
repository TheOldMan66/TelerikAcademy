using System;
using System.Text;

class Crosswords
{
    static string[] matrix;
    static string[] words;
    static int numWords;

    static bool DoMatrix(int row)
    {
        if (row == numWords)
        {
            bool matchWord = false;
            StringBuilder columns = new StringBuilder(numWords + 1);
            for (int i = 0; i < numWords; i++)
            {
                matchWord = false;
                columns.Clear();
                for (int j = 0; j < numWords; j++)
                    columns.Append(matrix[j][i]);
                string s = columns.ToString();
                for (int j = 0; j < words.Length; j++)
                {
                    if (s == words[j])
                    {
                        matchWord = true;
                        break;
                    }
                }
                if (!matchWord) break;
            }
            if (matchWord)
            {
                for (int i = 0; i < numWords; i++)
                    Console.WriteLine(matrix[i]);
                return true;
            }
            else
                return false;
        }
        for (int i = 0; i < words.Length; i++)
        {
            matrix[row] = words[i];
            if (DoMatrix(row + 1)) return true;
        }
        return false; // stupid compiler :)
    }

    static void Main()
    {
        numWords = int.Parse(Console.ReadLine());
        matrix = new string[numWords];
        words = new string[numWords * 2];
        for (int i = 0; i < numWords * 2; i++)
            words[i] = Console.ReadLine();
        Array.Sort(words);
        if(!DoMatrix(0))
        Console.WriteLine("NO SOLUTION!");
    }
}

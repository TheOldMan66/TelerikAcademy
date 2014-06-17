using System;
using System.IO;
using System.Text;

/* Write a program that reads a text file containing a list of strings, 
 * sorts them and saves them to another text file. */

class SortTextFile
{
    static string[] ReadFile()
    {
        string s;
        using (StreamReader reader = new StreamReader("input.txt"))
        {
            s = reader.ReadToEnd();
        }
        string[] words = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        if (words.Length == 0)
        {
            throw new FormatException();
        }
        return words;
    }

    static void WriteFile(string[] words)
    {
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            for (int i = 0; i < words.Length; i++)
                writer.WriteLine(words[i]);
        }
    }

    static void Main()
    {
        string[] words;
        try
        {
            words = ReadFile();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Input file not found");
            return;
        }
        catch (FormatException)
        {
            Console.WriteLine("Probably empty file.");
            return;
        }
        Console.WriteLine("Unsorted array:");
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
        Array.Sort(words);
        Console.WriteLine("Sorted array:");
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
        try
        {
            WriteFile(words);
        }
        catch (IOException)
        {
            Console.WriteLine("Cannot write data to file");
            return;
        }
        Console.WriteLine("Task complete. Sorted array is written to outpit file.");
    }
}
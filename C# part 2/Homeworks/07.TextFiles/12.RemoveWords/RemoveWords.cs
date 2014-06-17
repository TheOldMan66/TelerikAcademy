using System;
using System.IO;
using System.Collections.Generic;

/* Write a program that removes from a text file all words listed in given another text file.
 * Handle all possible exceptions in your methods. */

class RemoveWords
{

    static string CheckLine(string s, HashSet<string> dictionary)
    {
        string result = "";
        string[] words = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            if (!dictionary.Contains(words[i].ToUpper()))
            {
                if (result != "")
                    result = result + " ";
                result = result + words[i];
            }
        }
        return result;
    }


    static HashSet<string> ReadDictionary()
    {
        string[] words;
        HashSet<string> dictionary = new HashSet<string>();
        using (StreamReader reader = new StreamReader("dictionary.txt"))
        {
            while (!reader.EndOfStream)
            {
                words = reader.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in words)
                {
                    dictionary.Add(s.ToUpper());
                }
            }
        }
        return dictionary;
    }

    static void Main()
    {
        HashSet<string> dictionary;
        try
        {
            dictionary = ReadDictionary();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
            Console.WriteLine(ex.StackTrace);
            return;
        }
        try
        {
            using (StreamReader reader = new StreamReader("test.txt"))
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                while (!reader.EndOfStream)
                    writer.WriteLine(CheckLine(reader.ReadLine(), dictionary));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
            Console.WriteLine(ex.StackTrace);
            return;
        }
        Console.WriteLine("Task complete.");
    }
}
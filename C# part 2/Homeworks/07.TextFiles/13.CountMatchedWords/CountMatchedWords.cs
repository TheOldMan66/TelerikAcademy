using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class CountMatchedWords
{

    /* Write a program that reads a list of words from a file words.txt and finds 
     * how many times each of the words is contained in another file test.txt. 
     * The result should be written in the file result.txt and the words should be 
     * sorted by the number of their occurrences in descending order. 
     * Handle all possible exceptions in your methods. */

    static void CoundWordInLine(string line, Dictionary<string, int> dictionary)
    {
        string[] words = line.Split(new string[] { " ",",","." }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            string key;
            if (char.IsLetter(words[i][words[i].Length - 1]))
                key = words[i];
            else
                key = words[i].Substring(0, words[i].Length - 2);
            if (dictionary.ContainsKey(key))
                dictionary[key]++;
        }
    }


    static Dictionary<string, int> ReadDictionary()
    {
        string[] words;
        Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
        using (StreamReader reader = new StreamReader("words.txt"))
        {
            while (!reader.EndOfStream)
            {
                words = reader.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in words)
                    if (char.IsLetter(s[s.Length - 1]))
                        dictionary.Add(s, 0);
                    else
                        dictionary.Add(s.Substring(0, s.Length - 2), 0);
            }
        }
        return dictionary;
    }

    static void Main()
    {
        Dictionary<string, int> dictionary;
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
            {
                while (!reader.EndOfStream)
                    CoundWordInLine(reader.ReadLine(),dictionary);
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
            Console.WriteLine(ex.StackTrace);
            return;
        }
        try
        {
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                foreach (KeyValuePair<string, int> item in dictionary.OrderByDescending(key => key.Value))
                {
                    writer.WriteLine("Word: {0}, Count: {1}", item.Key, item.Value);
                }
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
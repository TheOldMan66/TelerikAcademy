using System;
using System.Collections.Generic;

/* A dictionary is stored as a sequence of text lines containing words and their explanations. 
 * Write a program that enters a word and translates it by using the dictionary. 
 * Sample dictionary: 
 .NET – platform for applications from Microsoft
 CLR – managed execution environment for .NET
 namespace – hierarchical organization of classes
 */

class MyDictionary
{
    static void Main()
    {
        string[] strDict = {".NET - platform for applications from Microsoft",
                                "CLR - managed execution environment for .NET",
                                "namespace - hierarchical organization of classes"};
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (string s in strDict)
        {
            string[] line = s.Split('-');
            dict.Add(line[0].Trim(), line[1].Trim());
        }
        Console.WriteLine("Enter word or 'END' to exit");
        string input;
        do
        {
            Console.Write("Enter word: ");
            input = Console.ReadLine();
            if (input.ToUpper() == "END")
            {
                Console.WriteLine("Good bye.");
                return;
            }
            if (dict.ContainsKey(input))
                Console.WriteLine("Definition for {0}: {1}", input, dict[input]);
            else
                Console.WriteLine("No definition for {0}", input);
        } while (true);
    }
}
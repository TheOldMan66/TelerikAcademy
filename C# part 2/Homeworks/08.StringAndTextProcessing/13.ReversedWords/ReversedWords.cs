using System;
using System.Collections.Generic;

/* Write a program that reverses the words in given sentence. Example: 
 * "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!". */

// Условието в слайда е объркано. Няма да се получи това което е дадено като пример.
// В нета има пълното условие от предни години - да се запазят местата на знаците за пунктуация. 
// Ще се придържам към него.

class ReversedWords
{
    static char GetLastChar(string word)
    {
        return word[word.Length - 1];
    }

    static void Main()
    {
        string input = "C# is not C++, not PHP and not Delphi!";
        string[] words = input.Split(' ');
        string output = "";
        List<char> puncuationSigns = new List<char>() { ',', '.', '!', '?' };
        for (int i = 0; i < words.Length; i++)
        {
            char endOfOriginalWord = GetLastChar(words[i]);
            char endOfNewWord = GetLastChar(words[words.Length - i - 1]);

            if (puncuationSigns.Contains(endOfNewWord))
                output = output + words[words.Length - i - 1].Substring(0, words[words.Length - i - 1].Length - 1);
            else
                output = output + words[words.Length - i - 1];

            if (puncuationSigns.Contains(endOfOriginalWord))
                output = output + words[i].Substring(words[i].Length - 1, 1);

            if (i < words.Length - 1)
                output = output + " ";
        }
        Console.WriteLine(output);
    }
}
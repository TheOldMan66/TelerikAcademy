using System;

class LetterIndex
{
    static void Main()
    {

        /* Write a program that creates an array containing all letters from the alphabet (A-Z).
         * Read a word from the console and print the index of each of its letters in the array. */

        char[] allLetters = new char[26];
        for (int i = 0; i < 26; i++)
            allLetters[i] = (char)(i + 65);
        Console.Write("Enter word: ");
        string word = Console.ReadLine();
        word = word.ToUpper();
        for (int i = 0; i < word.Length; i++)
            for (int j = 0; j < allLetters.Length; j++)
                if (word[i] == allLetters[j])
                {
                    Console.WriteLine("Letter {0} is {1}. Index in array of all letters is {2}.", i, word[i], j);
                    break;
                }
    }
}

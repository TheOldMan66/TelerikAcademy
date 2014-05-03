using System;
using System.Collections.Generic;

class QuickSort
{
    static void Main()
    {

        /* You are given an array of strings. Write a method that sorts the array 
         * by the length of its elements (the number of characters composing them). */

        Console.Write("Enter some sentence (copy/paste from internet :)): ");
        string s = Console.ReadLine();
        string[] wordList = s.Split(" .,!:-'()}{".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine();
        Array.Sort(wordList, (a, b) => a.Length.CompareTo(b.Length));
        foreach (string s1 in wordList)
            Console.Write(s1 + " ");
        Console.WriteLine();
    }
}

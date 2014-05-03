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
        List<string> wordList = new List<string>(s.Split(" .,!:-'()}{".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
        Console.WriteLine();
        MyQuickSort(wordList);
        foreach (string s1 in wordList)
            Console.Write(s1 + " ");
        Console.WriteLine();
    }

    static void MyQuickSort(List<string> arr)
    {
        if (arr.Count < 2)
            return;
        string pivot = arr[arr.Count / 2];
        List<string> leftArray = new List<string>(); 
        List<string> rightArray = new List<string>();

        for (int i = 0; i < arr.Count; i++)
        {
            if (i == arr.Count / 2)
                continue;
            if (arr[i].Length < pivot.Length)
                leftArray.Add(arr[i]); 
            else
                rightArray.Add(arr[i]);
        }
        MyQuickSort(leftArray); 
        MyQuickSort(rightArray);
        arr.Clear(); 
        arr.AddRange(leftArray); 
        arr.Add(pivot); 
        arr.AddRange(rightArray);
    }
}

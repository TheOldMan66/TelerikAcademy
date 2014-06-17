using System;
using System.Collections.Generic;

class QuickSort
{
    static void Main()
    {

        /* Write a program that sorts an array of strings using the 
         * quick sort algorithm (find it in Wikipedia). */

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
        if (arr.Count < 2) // list contain only one word - nothing to sort
            return;
        string pivot = arr[arr.Count / 2]; // get middle elemrnta as "pivot"
        List<string> leftArray = new List<string>(); // list of elemets smaller than pivot
        List<string> rightArray = new List<string>(); // list of elemets greater than pivot

        for (int i = 0; i < arr.Count; i++) // divide initial array to two subarray - with words smaller and larger than pivot word
        {
            if (i == arr.Count / 2) // we must exclude pivot, because we will add them manually in the middle
                continue;
            if (string.Compare(arr[i], pivot) < 0)
                leftArray.Add(arr[i]); // current word is smaller than pivot
            else
                rightArray.Add(arr[i]); // current word is greater (or equal) than pivot
        }
        MyQuickSort(leftArray); // recursive call for list of smaller words
        MyQuickSort(rightArray); // recursive call for list of greater words
        arr.Clear(); // clear input list
        arr.AddRange(leftArray); // add list of smaller words to "master" list
        arr.Add(pivot); // add pivot
        arr.AddRange(rightArray); // and then add list of greater words in master list.
    }
}

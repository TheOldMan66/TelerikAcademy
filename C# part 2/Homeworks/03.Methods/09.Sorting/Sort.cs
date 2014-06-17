using System;

class Sorting
{

    static int[] GenerateArray()
    {
        Random rnd = new Random();
        int[] array = new int[rnd.Next(20, 40)];
        for (int i = 0; i < array.Length; i++)
            array[i] = rnd.Next(100);
        return array;
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
            Console.Write("{0,3}", item);
        Console.WriteLine();
    }

    static int FindMax(int[] array, int startIndex, int endIndex)
    {
        int max = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
            if (array[i] > array[max])
                max = i;
        return max;
    }

    static void Swap(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    static void SortArray(int[] array, bool ascending)
    {
        if (ascending)
        {
            for (int i = array.Length - 1; i >= 0; i--)
                Swap(array, i, FindMax(array, 0, i));
        }
        else
        {
            for (int i = 0; i < array.Length; i++)
                Swap(array, i, FindMax(array, i, array.Length - 1));
        }
    }


    static void Main()
    {

        /* Write a method that return the maximal element in a portion of array of 
         * integers starting at given index. Using it write another method that sorts 
         * an array in ascending / descending order. */

        int[] array = GenerateArray();
        Console.WriteLine("Unsorted array: ");
        PrintArray(array);
        string ans = "";
        do
        {
            Console.Write("Enter 'A' for ascending or 'D' for descending sorting: ");
            ans = Console.ReadLine().ToUpper();
        } while (ans != "A" && ans != "D");
        bool ascending = ans == "A";
        SortArray(array, ascending);
        Console.WriteLine("Sorted array:");
        PrintArray(array);
    }
}

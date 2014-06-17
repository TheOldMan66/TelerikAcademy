using System;

class CountInts
{
    static int Count(int pattern, int[] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] == pattern)
                count++;
        return count;
    }


    static void Main()
    {

        /* Write a method that counts how many times given number appears in given array. 
         * Write a test program to check if the method is working correctly. */

        int[] arr = { 1, 2, 3, 4, 5, 8, 4, 1, 7, 4, 2, 9 };
        Console.WriteLine("Array is:");
        foreach (var item in arr)
            Console.Write("{0,3}", item);
        Console.WriteLine();
        Console.Write("Enter value to search for: ");
        int count = Count(int.Parse(Console.ReadLine()), arr);
        Console.WriteLine("This number have {0} occurences in array.", count);
    }
}

using System;

class Indexes
{
    static void Main()

    /* Write a program that allocates array of 20 integers and initializes each element 
     * by its index multiplied by 5. Print the obtained array on the console. */

    {
        int[] arr = new int[20];
        for (int i = 0; i < 20; i++)
        {
            arr[i] = i * 5;
        }
        Console.WriteLine("Array filled with index * 5:");
        for (int i = 0; i < arr.Length; i++)
            Console.Write("{0,4}", arr[i]);
    }
}


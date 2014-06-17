using System;

class FindNeighbors
{
    static bool IsBigger(int index, int[] array)
    {
        return (index > 0 && index < array.Length - 1 &&
                array[index] > array[index - 1] &&
                array[index] > array[index + 1]);
    }

    static int FindFirstBiggest(int[] array)
    {
        for (int i = 1; i < array.Length - 1; i++)
            if (IsBigger(i, array))
                return i;
        return -1;
    }

    static void Main()
    {

        /* Write a method that returns the index of the first element in array 
         * that is bigger than its neighbors, or -1, if there’s no such element.
         * Use the method from the previous exercise. */

        int[] arr = { 1, 2, 3, 4, 5, 8, 4, 1, 7, 4, 2, 9 };
//        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Array is:");
        foreach (var item in arr)
            Console.Write("{0,3}", item);
        Console.WriteLine();
        int index = FindFirstBiggest(arr);
        if (index == -1)
        {
            Console.WriteLine("No element which is biggest than its neighbors.");
        }
        else
        {
            Console.WriteLine("First element which is biggest than its neighbors is {0} (index {1}).", arr[index], index);
            Console.WriteLine("Sequence is {0}, {1}, {2}.", arr[index - 1], arr[index], arr[index + 1]);
        }
    }
}

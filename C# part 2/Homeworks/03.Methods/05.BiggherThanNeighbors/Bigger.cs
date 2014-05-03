using System;

class BiggerNeighbors
{
    static bool IsBigger(int index, int[] array)
    {
        return (index > 0 && index < array.Length - 1 && array[index] > array[index - 1] && array[index] > array[index + 1]);
    }


    static void Main()
    {

        /* Write a method that checks if the element at given position in given array of 
         * integers is bigger than its two neighbors (when such exist). */

        int[] arr = { 1, 2, 3, 4, 5, 8, 4, 1, 7, 4, 2, 9 };
        Console.WriteLine("Array is:");
        foreach (var item in arr)
            Console.Write("{0,3}", item);
        Console.WriteLine();
        Console.Write("Enter index of element to check is it bigger than its neighbors: ");
        int index = int.Parse(Console.ReadLine());
        if (index < 0 || index >= arr.Length)
        {
            Console.WriteLine("Index is out of range");
            return;
        }
        if (IsBigger(index,arr))
            Console.WriteLine("{0} is bigger than {1} and {2}",arr[index],arr[index-1],arr[index+1]);
        else
            Console.WriteLine("{0} is not bigger or dont have two neighbors", arr[index]);
    }
}

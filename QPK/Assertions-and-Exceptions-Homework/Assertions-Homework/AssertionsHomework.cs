using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("Null as input in SelectionSort");
        }

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        // Uncomment next line to see assert in action.
        //arr[3] = arr[0];

        // assertion if array is still not sorted.
#if DEBUG
        for (int index = 1; index < arr.Length; index++)
        {
            Debug.Assert(arr[index - 1].CompareTo(arr[index]) <= 0, "The array is not sorted after SelectionSort");
        }
#endif
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Null as input in FindMinElementIndex");
        Debug.Assert(startIndex > -1, "Start index < 0 in FindMinElementIndex");
        Debug.Assert(endIndex < arr.Length, "End index > array lenght in FindMinElementIndex");
        Debug.Assert(startIndex <= endIndex, "Start index > end index in FindMinElementIndex");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
#if DEBUG
        for (int index = startIndex; index <= endIndex; index++)
        {
            Debug.Assert(arr[minElementIndex].CompareTo(arr[index]) <= 0, "Smallest element not corrent after FindMinElementIndex");
        }
#endif
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        Debug.Assert(x != null && y != null, "Null as input in Swap");
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("Null as array input in BinatySearch.");
        }
        if (value == null)
        {
            throw new ArgumentNullException("Null as search value in BinatySearch.");
        }
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Null as array input in BinarySearch");
        Debug.Assert(value != null, "Null as search value in BinarySearch");
        Debug.Assert(startIndex > -1, "Start index < 0 in BinarySearch");
        Debug.Assert(endIndex < arr.Length, "End index > array lenght in BinarySearch");
        Debug.Assert(startIndex <= endIndex, "Start index > end index in BinarySearch");
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}

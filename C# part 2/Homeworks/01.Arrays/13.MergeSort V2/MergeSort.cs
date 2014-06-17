using System;

class MergeSortV2
{
    static int[] arr;

    static void Main()
    {

        /*  Write a program that sorts an array of integers using
         *  the merge sort algorithm (find it in Wikipedia). */

        // RECURSIVE SOLUTION - using less memory, working only with indexes.

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(10, 20);
            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(100);
        }
        else
        {
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // inpit is done.

        Console.WriteLine();
        Console.WriteLine("Unsorted array:");
        for (int i = 0; i < n; i++)
            Console.Write("{0,3}", arr[i]);
        Console.WriteLine();
        Console.WriteLine();

        int start = 0;
        int end = arr.Length - 1;
        MyMergeSort(start, end);

        Console.WriteLine();
        Console.WriteLine("Sorted array:");
        for (int i = 0; i < n; i++)
            Console.Write("{0,3}", arr[i]);
        Console.WriteLine();
    }

    static void MyMergeSort(int start, int end)
    {
        Console.Write("Split: ");
        for (int i = start; i <= end; i++)
            Console.Write("{0} ", arr[i]);

        if (end - start < 1)   // array contain only one element
        {
            Console.WriteLine(" <- Splited to single element");
            return;             // nothing to do, return.
        }
        else
            Console.WriteLine();
        int middle = start + (end - start) / 2;
        MyMergeSort(start, middle); // recursive call to MyMergeSort for left part
        MyMergeSort(middle + 1, end); // recursive call to MyMergeSort for right part

        //start of joining two parts
        Console.Write("Merge: ");
        for (int i = start; i <= middle; i++)
            Console.Write("{0} ", arr[i]);
        Console.Write("+ ");
        for (int i = middle+1; i <= end; i++)
            Console.Write("{0} ", arr[i]);
        Console.Write(" -> ");

        int leftMarker = start; // pointer for left array
        int rightMarker = middle + 1; // pointer for right array
        int[] tmpArray = new int[end - start + 1]; //temporary array
        int tmpMarker = 0; // pointer for temp array;
        do
        {
            if (arr[leftMarker] < arr[rightMarker])
            {
                tmpArray[tmpMarker] = arr[leftMarker];
                leftMarker++;
            }
            else
            {
                tmpArray[tmpMarker] = arr[rightMarker];
                rightMarker++;
            }
            tmpMarker++;
        } while (leftMarker <= middle && rightMarker <= end); // all pieces are moved, or there is pieces only in one subarray (no future comaprasion needed)

        for (int i = leftMarker; i <= middle; i++) // if there is some remaining elements in left subarray
        {
            tmpArray[tmpMarker] = arr[i];          // move them to root array;
            tmpMarker++;
        }
        for (int i = rightMarker; i <= end; i++) // same for right subarray;
        {
            tmpArray[tmpMarker] = arr[i];
            tmpMarker++;
        }
        Array.Copy(tmpArray, 0, arr, start, tmpArray.Length); // insert sorted temp array to original array
        foreach (int i in tmpArray)
            Console.Write("{0} ", i);
        Console.WriteLine();
    }
}
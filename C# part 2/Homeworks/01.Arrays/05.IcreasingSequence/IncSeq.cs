using System;

class IncSeq
{

    private static void PrintArray(int[] arr, int maxSeqStart, int maxSeqLen)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i >= maxSeqStart && i < maxSeqStart + maxSeqLen)
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0,2}", arr[i]);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.WriteLine();
    }

    
    static void Main()
    {

        /* Write a program that finds the maximal increasing sequence in an array. Example: 
            {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}. */
        
        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            // random size array with random numbers inside
            Random rnd = new Random();
            n = rnd.Next(30, 40); // array size 29 < n < 40
            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(10); // array element value 0-10
        }
        else
        {
            // user defined and filled array

            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // inpit is done.

        Console.WriteLine("Array is: ");
        PrintArray(arr, -1, -1);
        Console.WriteLine();

        int seqLen = 1;
        int maxSeqStart = 0;
        int maxSeqLen = 0;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > arr[i-1]) // current element is bigger than previous
                seqLen++; // yes - increase sequence
            else
            { // no, end of sequence
                if (seqLen >= maxSeqLen) // current sequence is bigger than biggest so far?
                {
                    maxSeqLen = seqLen; // yes - save new sequence lenght
                    maxSeqStart = i-seqLen; // and it's start point
                }
                seqLen = 1; // let's start new sequence
            }
        }

        // I can't figure out how to check if sequence ending at last elemet is biggest,
        // so I make final check outside the loop.

        if (seqLen >= maxSeqLen) 
        {
            maxSeqLen = seqLen;
            maxSeqStart = n - seqLen;
        }
        Console.WriteLine("Max sequence lenght is {0} (starting at pos {1})", maxSeqLen, maxSeqStart);
        PrintArray(arr, maxSeqStart, maxSeqLen);
    }
}


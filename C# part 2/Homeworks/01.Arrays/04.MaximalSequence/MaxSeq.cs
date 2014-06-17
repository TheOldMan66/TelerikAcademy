using System;

class MaxSeq
{

    private static void PrintMatrix(int[] arr, int maxSeqLen, int maxSeqStarPos)
    {
        // as name says, this function print one dimensional matrix ... :)

        for (int i = 0; i < arr.Length; i++)
        {
            if (i >= maxSeqStarPos && i < maxSeqStarPos + maxSeqLen) // let's add some color for max seqence
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0,2}", arr[i]);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.WriteLine();
    }


    static void Main(string[] args)
    {

        /* Write a program that finds the maximal sequence of equal elements in an array.
         * Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}. */

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            // fill randoms size array with random values
            Random rnd = new Random();
            n = rnd.Next(20, 30); // array size is 20 <= size < 30
            arr = new int[n];
            Console.WriteLine("Generated N is: {0}", n);
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(5); // 5 is max value for array element
        }
        else
        {
            // array will be filled by user

            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // inpit is done.

        Console.WriteLine("Array is: ");
        PrintMatrix(arr, -1, -1);
        Console.WriteLine();

        int maxSeqLen = 0;
        int maxSeqStarPos = 0;
        int seqLen = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - seqLen]) // currenr element = first element in sequence?
                seqLen++; // yes, increase lenght of sequence
            else
                seqLen = 1; // no, sequence is "fake", start new one
            if (seqLen > maxSeqLen) // current sequence is biggest for now?
            {
                maxSeqLen = seqLen; // yes - remember sequence size
                maxSeqStarPos = i - seqLen + 1; // and it's start point
            }
        }
        Console.WriteLine("Max sequence lenght is {0}, starting at position {1}.", maxSeqLen, maxSeqStarPos);
        PrintMatrix(arr, maxSeqLen, maxSeqStarPos);
    }
}

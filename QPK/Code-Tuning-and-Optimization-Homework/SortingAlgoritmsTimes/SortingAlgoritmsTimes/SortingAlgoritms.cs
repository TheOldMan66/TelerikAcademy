using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SortingAlgoritmsTimes
{
    class SortingAlgoritms
    {
        static Random rndGen = new Random();
        static void InsertionSort<T>(T[] arr) where T: IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                T value = arr[i];
                int index = i;
                while (index > 0 && arr[index - 1].CompareTo(value) > 0)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }
                arr[index] = value;
            }
        }

        static void SelectionSort<T>(T[] arr) where T:IComparable<T>
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j]) > 0)
                    {
                        T value = arr[i];
                        arr[i] = arr[j];
                        arr[j] = value;
                    }
                }
            }
        }

        static void QuickSort<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            int i = left, j = right;
            T pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T value = arr[i];
                    arr[i] = arr[j];
                    arr[j] = value;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(arr, left, j);
            }

            if (i < right)
            {
                QuickSort(arr, i, right);
            }
        }


        static void GenerateIntArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rndGen.Next();
            }
        }

        static void GenerateDoubleArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1.258* rndGen.Next();
            }
        }
        static void GenerateStringArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int arrLen = rndGen.Next(20) + 20;
                StringBuilder builder = new StringBuilder(40);
                for (int j = 0; j < arrLen; j++)
                {
                    builder.Append((char)(rndGen.Next(64) + 64));
                }
                arr[i] = builder.ToString();
            }
        }

        static void Main(string[] args)
        {
            int iterations = 10000;
            int[] intArray = new int[iterations];
            Double[] doubleArray = new double[iterations];
            string[] stringArray = new string[iterations];
            Stopwatch stopwatch = new Stopwatch();

            // array of int's
            Console.WriteLine("Array of {0} integers.",iterations);
            Console.WriteLine();

            // insertion sort
            Console.Write("Insertion sort. Generating Array.");
            GenerateIntArray(intArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Start();
            InsertionSort(intArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.",stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            InsertionSort(intArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);
            
            Array.Reverse(intArray);
            
            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            InsertionSort(intArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            // Selection sort
            Console.WriteLine();
            Console.Write("Selection sort. Generating Array.");
            GenerateIntArray(intArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Restart();
            SelectionSort(intArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            SelectionSort(intArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(intArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            SelectionSort(intArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            // Quick sort
            Console.WriteLine();
            Console.Write("Quick sort. Generating Array.");
            GenerateIntArray(intArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Restart();
            QuickSort(intArray, 0, intArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            QuickSort(intArray, 0, intArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(intArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            QuickSort(intArray, 0, intArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.Write("Press <ENTER> to continue.");
            Console.ReadLine();


            // array of doubles
            Console.WriteLine("Array of {0} doubles.", iterations);
            Console.WriteLine();

            // insertion sort
            Console.Write("Insertion sort. Generating Array.");
            GenerateDoubleArray(doubleArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Start();
            InsertionSort(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            InsertionSort(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(doubleArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            InsertionSort(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            // Selection sort
            Console.WriteLine();
            Console.Write("Selection sort. Generating Array.");
            GenerateDoubleArray(doubleArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Restart();
            SelectionSort(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            SelectionSort(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(doubleArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            SelectionSort(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            // Quick sort
            Console.WriteLine();
            Console.Write("Quick sort. Generating Array.");
            GenerateDoubleArray(doubleArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Restart();
            QuickSort(doubleArray, 0, doubleArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            QuickSort(doubleArray, 0, doubleArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(doubleArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            QuickSort(doubleArray, 0, doubleArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.Write("Press <ENTER> to continue.");
            Console.ReadLine();


            // array of strings

            Console.WriteLine("Array of {0} strings.", iterations);
            Console.WriteLine();

            // insertion sort
            Console.Write("Insertion sort. Generating Array.");
            GenerateStringArray(stringArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Start();
            InsertionSort(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            InsertionSort(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(stringArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            InsertionSort(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            // Selection sort
            Console.WriteLine();
            Console.Write("Selection sort. Generating Array.");
            GenerateStringArray(stringArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Restart();
            SelectionSort(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            SelectionSort(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(stringArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            SelectionSort(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            // Quick sort
            Console.WriteLine();
            Console.Write("Quick sort. Generating Array.");
            GenerateStringArray(stringArray);
            Console.WriteLine("Done.");
            Console.WriteLine("Sorting array with random values.");
            stopwatch.Restart();
            QuickSort(stringArray, 0, stringArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Sorting array with already sorted elements.");
            stopwatch.Restart();
            QuickSort(stringArray, 0, stringArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Array.Reverse(stringArray);

            Console.WriteLine("Sorting array with elements sorted by reverse.");
            stopwatch.Restart();
            QuickSort(stringArray, 0, stringArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Done. Sorting time: {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.Write("Press <ENTER> to continue.");
            Console.ReadLine();
        }
    }
}

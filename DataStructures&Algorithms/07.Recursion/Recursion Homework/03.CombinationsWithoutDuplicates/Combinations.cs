using System;
namespace _01.NestedFors
{
    class NestedFors
    {
        public static void Recursion(int end, int[] arr, int start = 1, int currentLevelOfRecursion = 0)
        {
            if (currentLevelOfRecursion == arr.Length)
            {
                Console.WriteLine("(" + string.Join(" ", arr) + ")");
                return;
            }

            for (int i = start; i <= end; i++)
            {
                arr[currentLevelOfRecursion] = i;
                Recursion(end, arr, i + 1, currentLevelOfRecursion + 1);
            }
        }

        static void Main(string[] args)
        {
            int n = 5;
            int k = 3;
            int[] arr = new int[k];
            Recursion(n, arr);
        }
    }
}

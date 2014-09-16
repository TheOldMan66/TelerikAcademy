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
                Recursion(end, arr, i, currentLevelOfRecursion + 1);
            }
        }

        static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            int[] arr = new int[2];
            Recursion(n, arr);
        }
    }
}

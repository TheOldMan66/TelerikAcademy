using System;
namespace _01.NestedFors
{
    class NestedFors
    {
        public static void Recursion(int[] arr, int n = 0)
        {
            if (n == arr.Length)
            {
                Console.WriteLine(string.Join(", ",arr));
                return;
            }
            for (int i = 1; i <= arr.Length; i++)
            {
                arr[n] = i;
                Recursion(arr, n + 1);
            }
        }

        static void Main(string[] args)
        {
            int n = 3;
            int[] arr = new int[n];
            Recursion(arr);
        }
    }
}

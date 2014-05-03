using System;

    class CharArrays
    {
        static void Main()
        {

            /* Write a program that compares two char arrays 
             * lexicographically (letter by letter). */

            Console.Write("Enter first char array (as string): ");
            string input = Console.ReadLine();
            char[] arr1 = input.ToCharArray();
            Console.Write("Enter second char array (as string): ");
            input = Console.ReadLine();
            char[] arr2 = input.ToCharArray();
            if (arr1.Length != arr2.Length) // arrays have differnet size, no need to check content
            {
                Console.WriteLine("Arrays are different");
                return;
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine("Arrays are different");
                    return;
                }
            }
            Console.WriteLine("Arrays are equal");
        }
    }

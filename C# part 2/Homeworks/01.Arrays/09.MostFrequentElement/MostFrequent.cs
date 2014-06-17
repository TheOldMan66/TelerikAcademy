using System;
using System.Collections;
class MostFrequent
{
    static void Main()
    {

        /* Write a program that finds the most frequent number in an array. Example:
         * {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times) */

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            // random generated array

            Random rnd = new Random();
            n = rnd.Next(20, 30);
            arr = new int[n];
            Console.WriteLine("Generated N is: {0}", n);
            Console.WriteLine("Generated array is:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(10);
                Console.Write("{0,2}", arr[i]);
            }
            Console.WriteLine();
        }
        else
        {
            // user defined and fileld array

            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // input is done

        SortedList count = new SortedList(); // I use SortedList to automate some work. "Index" field is value of element, "value" element is count of this elements
        for (int i = 0; i < arr.Length; i++) // let's walk in array - form start to end
        {
            int index = count.IndexOfKey(arr[i]); // is this element already in sorted list?
            if (index < 0) 
                count.Add(arr[i], 1); // no, this element is not in the list. Add them, and place "1" at count position
            else
                count[arr[i]] = (int)count[arr[i]]+1 ; // yes, element is in the list. Add 1 to count position.
        }

        //count of all elements is done
        
        int maxPos = 0; // now we must find which element have biggest count (in "value" fielt in sorted array)
        int maxValue = (int)count.GetByIndex(0); // get first element for starting
        for (int i = 1; i < count.Count; i++)
        {
            if (maxValue < (int)count.GetByIndex(i))
            {
                maxPos = i;
                maxValue = (int)count.GetByIndex(i);
            }
        }
        //finding the most frequent element is done

        Console.WriteLine("Value {0} is most frequent - {1} times",count.GetKey(maxPos),maxValue) ;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == (int)count.GetKey(maxPos))
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0,2}", arr[i]);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.WriteLine();
    }
}

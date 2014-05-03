using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DivisibleNumbers
{
    class Divisible
    {
        static void Main(string[] args)
        {
            /* Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
             * Use the built-in extension methods and lambda expressions. ...*/
            Console.WriteLine("With lambda extension:");
            int[] input = new int[200];
            for (int i = 0; i < 200; i++)
                input[i] = i;
            var divisibleInts = input.Where(element => (element % 7 == 0 && element % 3 == 0 ));
            foreach (int div in divisibleInts)
                Console.WriteLine(div);
            Console.WriteLine();

            /* ... Rewrite the same with LINQ. */
            Console.WriteLine("With LINQ:");
            divisibleInts = 
                from divisible in input
                where divisible %7 == 0 && divisible %3 == 0
                    select divisible;
            foreach (int v in divisibleInts)
                Console.WriteLine(v);
            Console.WriteLine();
        }
    }
}

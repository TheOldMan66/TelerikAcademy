/* Write a program that calculates for given N how many trailing zeros present 
 * at the end of the number N!. Examples:
	N = 10  N! = 3628800  2
	N = 20  N! = 2432902008176640000  4
	Does your program work for N = 50 000?
	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. 
 * Think why! */

using System;

namespace _12.HowManyTrailingZeros
{
    class TrailingZeros
    {
        static void Main()
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int fives = 5;
            do
            {
                sum = sum + (n / fives);
                fives = fives * 5;
            } while (n > fives);
            Console.WriteLine("\n{0}! have {1} trailing zeroes.\n", n, sum);
        }
    }
}

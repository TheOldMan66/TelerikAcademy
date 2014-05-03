/*  Write a program that reads a positive integer number N (N < 20) from console and outputs 
 * in the console the numbers 1 ... N numbers arranged as a spiral. Example for N = 4 
        1   2   3   4   
        12  13  14  5
        11  16  15  6
        10  9   8   7 */

using System;


namespace _13.Spiral
{
    class Spiral
    {
        static void Main()
        {
            // Sorry, no comments... Please, look at next project - Spiral Ver.2... :)
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int upperRow = 0;
            int lowerRow = n-1;
            int leftColumn = 0;
            int rightColumn = n-1;
            int count = 1;
            int x = leftColumn;
            int y = upperRow+1;
            do
            {
                while (x <= rightColumn)
                {
                    matrix[x, upperRow] = count;
                    x++;
                    count++;
                }
                upperRow++;
                x--;

                while (y <= lowerRow)
                {
                    matrix[rightColumn, y] = count;
                    y++;
                    count++;
                }
                rightColumn--;
                y--;

                while (x > leftColumn)
                {
                    x--;
                    matrix[x, lowerRow] = count;
                    count++;
                }
                lowerRow--;
                x++;

                while (y > upperRow)
                {
                    y--;
                    matrix[leftColumn, y] = count;
                    count++;
                }
                leftColumn++;
                y++;

            } while (count <= n * n);


            string divider = "+";
            for (int i = 0; i < n; i++)
            {
                divider = divider + "---+";
            }
            Console.WriteLine(divider);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("|{0,3}", matrix[j, i]);
                }
                Console.WriteLine("|");
                Console.WriteLine(divider);
            }
        }
    }
}

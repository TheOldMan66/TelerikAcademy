/*  Write a program that reads a positive integer number N (N < 20) from console and outputs 
 * in the console the numbers 1 ... N numbers arranged as a spiral. Example for N = 4 
        1   2   3   4   
        12  13  14  5
        11  16  15  6
        10  9   8   7 */

using System;


namespace _13.SpiralV2
{
    class SpiralV2
    {
        static void Main()
        {
            Console.Write("Enter value for N : ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int upperRow = 0; // First unfilled row
            int lowerRow = n - 1; // Last unfilled row
            int leftColumn = 0; // Left unfilled column
            int rightColumn = n - 1; // Right unfilled column
            int count = 1; // Where we are - form 1 to N*N
            do
            {
                for (int i = leftColumn; i <= rightColumn; i++) // place numbers on first availiable row
                {
                    matrix[i, upperRow] = count;
                    count++;
                }
                upperRow++; // This row is done, no future work with him.

                for (int i = upperRow; i <= lowerRow; i++) // Fill the rightmost empty column
                {
                    matrix[rightColumn, i] = count;
                    count++;
                }
                rightColumn--; // column is done, move boundary to the left

                for (int i = rightColumn; i >= leftColumn; i--) // Deal with deepest empty row.
                {
                    matrix[i, lowerRow] = count;
                    count++;
                }
                lowerRow--; // row is done, move boundary up

                for (int i = lowerRow; i >= upperRow; i--) // and finally work with leftmost available column
                {
                    matrix[leftColumn, i] = count;
                    count++;
                }
                leftColumn++; // adjust left limiter for row loops

            } while (count <= n * n); 

            string divider = "+"; // Let's make good looking grid
            for (int i = 0; i < n; i++)
            {
                divider = divider + "---+";
            }
            Console.WriteLine(divider); // top of table
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("|{0,3}", matrix[j, i]); // print formatted values (with spacers)
                }
                Console.WriteLine("|");
                Console.WriteLine(divider); // bottom of table
            }
        }
    }
}

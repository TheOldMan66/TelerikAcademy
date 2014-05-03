﻿using System;
using System.Collections.Generic;

class Point
{
    public int row;
    public int colunm;

    public Point(int r, int c)
    {
        this.row = r;
        this.colunm = c;
    }
}

class Directions
{
    public int rowChange;
    public int colChange;

    public Directions(int row, int col)
    {
        rowChange = row;
        colChange = col;
    }
}


class MaxSubmatrixSum
{
    static int[,] matrix;
    static bool[,] visited;
    static Directions[] directions = new Directions[8]
            {   new Directions( 1,-1),
                new Directions( 1,0),
                new Directions( 1,1),
                new Directions( 0,1),
                new Directions( -1,1),
                new Directions( -1,0),
                new Directions( -1,-1),
                new Directions( 0,-1),
            };

    private static void PrintMatrix(List<Point> sequence)
    {
        string divider = "+";
        for (int cols = 0; cols < matrix.GetLength(1); cols++)
            divider = divider + "---+";
        Console.WriteLine(divider);
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                Console.Write("|");
                for (int k = 0; k < sequence.Count; k++)
                    if (sequence[k].row == rows && sequence[k].colunm == cols)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                Console.Write("{0,3}", matrix[rows, cols]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("|");
            Console.WriteLine(divider);
        }
        Console.WriteLine();
    }

    static void GetArea(int row, int col, List<Point> sequence)
    {
        Point currentPoint = new Point(row, col);
        sequence.Add(currentPoint);

        //Console.Write("{0} {1} {2} ", row, col, sequence.Count);
        //if (sequence.Count > 0)
        //{
        //    Console.Write(" -> ");
        //    for (int i = 0; i < sequence.Count; i++)
        //    {
        //        Console.Write("({0},{1}), ", sequence[i].row, sequence[i].colunm);
        //    }
        //    Console.WriteLine();
        //}
        //else
        //    Console.WriteLine();

        visited[row, col] = true;
        int newRow;
        int newCol;
        for (int direction = 0; direction < 8; direction++)
        {
            newRow = row + directions[direction].rowChange;
            newCol = col + directions[direction].colChange;
            if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1) &&
                !visited[newRow, newCol] && matrix[newRow, newCol] == matrix[row, col])
                GetArea(newRow, newCol, sequence);
        }
    }

    static void Main()

    /* Write a program that finds the largest area of equal neighbor elements 
     * in a rectangular matrix and prints its size. */
    {
        int n;
        int m;

        matrix = new int[,]
        {   {1, 3, 2, 2, 2, 4},
            {3, 3, 3, 2, 4, 4},
            {4, 3, 1, 2, 3, 3},
            {4, 3, 1, 3, 3, 1},
            {4, 3, 3, 3, 1, 1}     };

        Console.Write("Enter 'A' for autogenerated random array or 'P' for hardcoded array: ");
        string s = Console.ReadLine().ToUpper();
        Console.WriteLine();
        if (s == "A")
        {
            Random rnd = new Random();
            n = rnd.Next(10, 15);
            m = rnd.Next(15, 20);
            matrix = new int[n, m];
            for (int row = 0; row < n; row++)
                for (int col = 0; col < m; col++)
                    matrix[row, col] = rnd.Next(5);
        }
        else
        {
            n = matrix.GetLength(0);
            m = matrix.GetLength(1);
        }

        // input is done

        visited = new bool[n, m];
        List<Point> sequence = new List<Point>();
        List<Point> maxSequence = new List<Point>();

        for (int row = 0; row < n - 1; row++)
            for (int col = 0; col < m - 1; col++)
            {
                if (!visited[row, col])
                {
                    GetArea(row, col, sequence);
                    if (sequence.Count > maxSequence.Count)
                    {
                        maxSequence = sequence;
                        sequence = new List<Point>();
                    }
                }
                sequence.Clear();
            }
        Console.WriteLine("Maximum area of equal neighbor elements is {0}", maxSequence.Count);
        PrintMatrix(maxSequence);
    }
}

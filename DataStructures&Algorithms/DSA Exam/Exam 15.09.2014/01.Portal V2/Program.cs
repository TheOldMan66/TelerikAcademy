using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_15._09._2014
{
    public class Cell
    {
        public Cell(int[] coords)
        {
            this.row = coords[0];
            this.col = coords[1];
        }
        public Cell(int r, int c)
        {
            this.row = r;
            this.col = c;
        }

        public int row;
        public int col;
    }

    class Program
    {
        static int maxSum = 0;
        static int[,] matrix;
        static bool[,] visited;

        static int GetCellValue(Cell cell)
        {
            return matrix[cell.row, cell.col];
        }

        static bool InCell(Cell cell)
        {
            return cell.row > -1 && cell.row < matrix.GetLength(0) &&
                cell.col > -1 && cell.col < matrix.GetLength(1);
        }

        static void Recursion(Cell currentCell, int sumSoFar)
        {
            if (!InCell(currentCell) || visited[currentCell.row, currentCell.col])
            {
                if (sumSoFar > maxSum)
                {
                    maxSum = sumSoFar;
                }
                return;
            }

            sumSoFar += GetCellValue(currentCell);
            visited[currentCell.row, currentCell.col] = true;
            Recursion(new Cell(currentCell.row + GetCellValue(currentCell), currentCell.col), sumSoFar);
            Recursion(new Cell(currentCell.row - GetCellValue(currentCell), currentCell.col), sumSoFar);
            Recursion(new Cell(currentCell.row, currentCell.col + GetCellValue(currentCell)), sumSoFar);
            Recursion(new Cell(currentCell.row, currentCell.col - GetCellValue(currentCell)), sumSoFar);
            sumSoFar -= GetCellValue(currentCell);
            visited[currentCell.row, currentCell.col] = false;
        }

        static void Main(string[] args)
        {
            Cell startingPosition = new Cell(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Cell mazeSize = new Cell(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            matrix = new int[mazeSize.row, mazeSize.col];
            visited = new bool[mazeSize.row, mazeSize.col];
            for (int i = 0; i < mazeSize.row; i++)
            {
                string[] rowInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < rowInput.Length; j++)
                {
                    if (!rowInput[j].Contains('#'))
                    {
                        matrix[i, j] = int.Parse(rowInput[j]);
                    }
                    else
                    {
                        visited[i, j] = true;
                        //                        matrix[i, j] = -1;
                    }
                }
            }

            Recursion(startingPosition, 0);
            Console.WriteLine(maxSum);
        }
    }
}

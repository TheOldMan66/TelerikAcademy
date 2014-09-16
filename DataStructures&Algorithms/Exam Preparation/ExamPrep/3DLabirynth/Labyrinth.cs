using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLabirynth
{

    class Coordinates
    {
        public int row;
        public int col;
        public int level;

        public Coordinates(int l, int r, int c)
        {
            this.row = r;
            this.col = c;
            this.level = l;
        }

        public Coordinates(int[] arr)
        {
            this.row = arr[1];
            this.col = arr[2];
            this.level = arr[0];
        }

        public Coordinates(Coordinates other)
        {
            this.row = other.row;
            this.col = other.col;
            this.level = other.level;
        }

    }

    class Cell
    {
        public char sign;
        public int len;
        public bool visited;

        public Cell(char c, int l, bool v)
        {
            this.sign = c;
            this.len = l;
            this.visited = v;
        }

    }

    class Labyrinth
    {
        static Cell[, ,] matrix;

        static Cell GetCell(Coordinates coords)
        {
            return matrix[coords.level, coords.row, coords.col];
        }


        static void Main(string[] args)
        {
            Coordinates startCell = new Coordinates(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Coordinates matrixSize = new Coordinates(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            matrix = new Cell[matrixSize.level, matrixSize.row, matrixSize.col];
            string input;
            for (int i = 0; i < matrixSize.level; i++)
            {
                for (int j = 0; j < matrixSize.row; j++)
                {
                    input = Console.ReadLine();
                    for (int k = 0; k < input.Length; k++)
                    {
                        matrix[i, j, k] = new Cell(input[k], 0, false);
                    }
                }
            }

            Queue<Coordinates> queue = new Queue<Coordinates>();
            queue.Enqueue(startCell);
            Coordinates currentCell;
            int lenCounter;
            while (queue.Count > 0)
            {
                currentCell = queue.Dequeue();
                lenCounter = matrix[currentCell.level, currentCell.row, currentCell.col].len;
                matrix[currentCell.level, currentCell.row, currentCell.col].visited = true;
//                Console.WriteLine("{2}, {0}, {1}", currentCell.row, currentCell.col, currentCell.level);
                //Left
                currentCell.col--;
                if (currentCell.col >= 0 &&
                    !GetCell(currentCell).visited &&
                    GetCell(currentCell).sign != '#')
                {
                    matrix[currentCell.level, currentCell.row, currentCell.col].len = lenCounter + 1;
                    queue.Enqueue(new Coordinates(currentCell));
                }

                //Right
                currentCell.col += 2;
                if (currentCell.col < matrixSize.col &&
                    !GetCell(currentCell).visited &&
                    GetCell(currentCell).sign != '#')
                {
                    matrix[currentCell.level, currentCell.row, currentCell.col].len = lenCounter + 1;
                    queue.Enqueue(new Coordinates(currentCell));
                }
                //Up
                currentCell.col--;
                currentCell.row--;
                if (currentCell.row >= 0 &&
                    !GetCell(currentCell).visited &&
                    GetCell(currentCell).sign != '#')
                {
                    matrix[currentCell.level, currentCell.row, currentCell.col].len = lenCounter + 1;
                    queue.Enqueue(new Coordinates(currentCell));
                }

                //Down
                currentCell.row += 2;
                if (currentCell.row < matrixSize.row &&
                    !GetCell(currentCell).visited &&
                    GetCell(currentCell).sign != '#')
                {
                    matrix[currentCell.level, currentCell.row, currentCell.col].len = lenCounter + 1;
                    queue.Enqueue(new Coordinates(currentCell));
                }
                //Level-
                currentCell.row--;
                if (GetCell(currentCell).sign == 'D')
                {
                    currentCell.level--;
                    if (currentCell.level < 0)
                    {
                        Console.WriteLine(matrix[currentCell.level+1, currentCell.row, currentCell.col].len+1);
                        Environment.Exit(0);
                    }

                    if (currentCell.level >= 0 &&
                        !GetCell(currentCell).visited &&
                        GetCell(currentCell).sign != '#')
                    {
                        matrix[currentCell.level, currentCell.row, currentCell.col].len = lenCounter + 1;
                        queue.Enqueue(new Coordinates(currentCell));
                    }
                }

                //Level-
                if (GetCell(currentCell).sign == 'U')
                {
                    currentCell.level++;
                    if (currentCell.level == matrixSize.level)
                    {
                        Console.WriteLine(matrix[currentCell.level-1, currentCell.row, currentCell.col].len+1);
                        Environment.Exit(0);
                    }
                    if (currentCell.level < matrixSize.level &&
                        !GetCell(currentCell).visited &&
                        GetCell(currentCell).sign != '#')
                    {
                        matrix[currentCell.level, currentCell.row, currentCell.col].len = lenCounter + 1;
                        queue.Enqueue(new Coordinates(currentCell));
                    }
                }
                lenCounter++;
            }
        }
    }
}

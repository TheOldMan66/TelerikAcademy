using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PathBetweenTwoCells
{
    public class MazeCell : IEquatable<MazeCell>
    {
        public int row;
        public int col;

        public MazeCell()
        {
        }

        public MazeCell(MazeCell original)
        {
            this.row = original.row;
            this.col = original.col;
        }

        public bool Equals(MazeCell other)
        {
            return this.row == other.row && this.col == other.col;
        }

        public override string ToString()
        {
            return "(" + this.row + "," + this.col + ")";
        }

        public void ShowCell()
        {
            Console.SetCursorPosition(this.col, this.row);
            Console.Write('*');
        }
        public void HideCell()
        {
            Console.SetCursorPosition(this.col, this.row);
            Console.Write(' ');
        }

    }

    class MazeSolver
    {
        public static bool[,] maze;
        public static string[] strMaze = new string[] {
"+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+",
"  |   |         |               |       |",
"+ + + + + +-+-+ +-+ +-+-+-+ +-+ +-+-+ +-+",
"|   |   |     |     |     |   |         |",
"+-+-+-+-+-+-+-+-+-+-+ +-+ +-+ +-+-+-+-+ +",
"|   | |       |     |   |     |   |   | |",
"+ + + + +-+-+-+-+-+-+-+ +-+-+-+ +-+ + + +",
"| | |   |     |     |   |     | |   | | |",
"+ +-+ +-+ +-+ +-+-+ + +-+ +-+ + +-+-+-+ +",
"|     |   | |   |     | | |   |         |",
"+ +-+-+ +-+ +-+-+-+ + + + + +-+ +-+-+-+-+",
"| |   | |       |   | | | | |   |       |",
"+-+ + + + +-+-+ + +-+ + + + + +-+-+-+-+ +",
"|   |   | |   | | |   |   | | |         |",
"+ +-+ +-+ + + +-+ + +-+-+ +-+ +-+-+-+-+-+",
"|   |   | | | |   | |   |     | |   |   |",
"+-+ +-+ + + + + +-+ + +-+-+-+-+ + + +-+ +",
"|   |   | | | |   | | |   |       |     |",
"+ +-+ +-+ + + +-+-+ + + + + +-+ +-+-+ +-+",
"|   | | |   |   |       | |   | |     | |",
"+-+ + + +-+-+-+-+ +-+-+-+ +-+ + + +-+-+ +",
"|   | |       |   | |   | |   | | |   | |",
"+ +-+-+-+-+-+ + +-+ + + + + +-+ + + + + +",
"|   |     |   |   |   | | | |   |   | | |",
"+-+ +-+-+ + +-+ + +-+-+ + + + +-+-+-+ + +",
"|   | |     |   |     | |   | |   |     |",
"+ +-+ + +-+-+ +-+-+-+ + +-+-+ + + +-+-+-+",
"|     | |   |   |   |   |     | | |     |",
"+-+-+ + +-+ +-+ + + +-+-+ +-+-+-+ + +-+ +",
"|   | |     |   | |     |   |   | |   | |",
"+ +-+ + +-+-+ +-+ +-+-+ +-+-+-+ + +-+-+ +",
"| |   | |     |   |   | |   |   |       |",
"+ + +-+-+-+-+-+ +-+ +-+ + + + +-+-+-+-+ +",
"| | |     |   | | | |   | | |         | |",
"+ + + +-+ + + + + + + +-+ +-+-+ +-+-+ + +",
"| | | |   | |   | |     |       |   | | |",
"+ + + +-+-+ +-+ + +-+-+ +-+-+-+-+ + +-+ +",
"|   | |   | | |   |   | |         |     |",
"+-+ + + + + + +-+-+ + +-+ +-+-+-+ +-+-+ +",
"|   |   |           |     |       |      ",
"+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+"};

        public bool IsFree(MazeCell cell)
        {
            if (cell.row >= 0 && cell.row < maze.GetLength(0) && cell.col >= 0 && cell.col < maze.GetLength(1))
            {
                return maze[cell.row, cell.col];
            }
            else
            {
                return false;
            }

        }

        public void GenrateMaze()
        {
            maze = new bool[strMaze.Length, strMaze[0].Length];
            for (int i = 0; i < strMaze.Length; i++)
            {
                for (int j = 0; j < strMaze[i].Length; j++)
                {
                    maze[i, j] = strMaze[i][j] == ' ';
                }
            }

        }

        Queue<Stack<MazeCell>> queue = new Queue<Stack<MazeCell>>();

        public int RecursiveSolverBFS()
        {
            Stack<MazeCell> currentRoute;
            MazeCell currentCell;
            int maxQueueSize = 0;
            while (queue.Count > 0)
            {
                currentRoute = queue.Dequeue();
                currentCell = currentRoute.Peek();

                Stack<MazeCell> newRoute = new Stack<MazeCell>(currentRoute);
                MazeCell newCell = new MazeCell(currentCell);
                newCell.row = currentCell.row - 1;
                if (IsFree(newCell) && !currentRoute.Contains(newCell))
                {
                    newRoute.Push(newCell);
                    newCell.ShowCell();
                    queue.Enqueue(newRoute);
                    maze[newCell.row, newCell.col] = false;
                }

                newRoute = new Stack<MazeCell>(currentRoute);
                newCell = new MazeCell(currentCell);
                newCell.row = currentCell.row + 1;
                if (IsFree(newCell) && !currentRoute.Contains(newCell))
                {
                    newRoute.Push(newCell);
                    newCell.ShowCell();
                    queue.Enqueue(newRoute);
                    maze[newCell.row, newCell.col] = false;
                }

                newRoute = new Stack<MazeCell>(currentRoute);
                newCell = new MazeCell(currentCell);
                newCell.col = currentCell.col - 1;
                if (IsFree(newCell) && !currentRoute.Contains(newCell))
                {
                    newRoute.Push(newCell);
                    newCell.ShowCell();
                    queue.Enqueue(newRoute);
                    maze[newCell.row, newCell.col] = false;
                }

                newRoute = new Stack<MazeCell>(currentRoute);
                newCell = new MazeCell(currentCell);
                newCell.col = currentCell.col + 1;
                if (IsFree(newCell) && !currentRoute.Contains(newCell))
                {
                    newRoute.Push(newCell);
                    newCell.ShowCell();
                    queue.Enqueue(newRoute);
                    maze[newCell.row, newCell.col] = false;
                }

                if (maxQueueSize < newRoute.Count)
                {
                    maxQueueSize = newRoute.Count;
                }
            }
            return maxQueueSize;
        }

        public int SolveMazeBFS(MazeCell startCell, int color)
        {
            int maxRoute = 0;
            Console.ForegroundColor = (ConsoleColor)color;
            Console.SetCursorPosition(0, maze.GetLength(0) + 1);
            Console.WriteLine("Press ENTER for next area");
            Console.ReadLine();
            Stack<MazeCell> currentRoute = new Stack<MazeCell>();
            MazeCell currentCell = new MazeCell(startCell);
            currentRoute.Push(currentCell);
            queue.Enqueue(currentRoute);
            int currentRouteSize = RecursiveSolverBFS();
            if (currentRouteSize > maxRoute)
            {
                maxRoute = currentRouteSize;
            }
            return maxRoute;
        }
    }



    class FindPathBetweenPoints
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 50;
            MazeSolver solver = new MazeSolver();
            solver.GenrateMaze();
            bool hasEmptyArea = true;
            int color = 4;
            int maxAreaSize = 0;
            Console.Clear();
            foreach (var row in MazeSolver.strMaze)
            {
                Console.WriteLine(row);
            }
            while (hasEmptyArea)
            {
                for (int row = 0; row < MazeSolver.maze.GetLength(0); row++)
                {
                    for (int col = 0; col < MazeSolver.maze.GetLength(1); col++)
                    {
                        if (MazeSolver.maze[row, col])
                        {
                            MazeCell emptyCell = new MazeCell();
                            emptyCell.row = row;
                            emptyCell.col = col;
                            int currentAreaSize = solver.SolveMazeBFS(emptyCell, color);
                            if (currentAreaSize > maxAreaSize)
                            {
                                maxAreaSize = currentAreaSize;
                            }
                            color++;
                        }
                        else
                        {
                            hasEmptyArea = false;
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, MazeSolver.maze.GetLength(0) + 1);
            Console.WriteLine("Max area size is {0} elements,",maxAreaSize);
        } 
    }
}
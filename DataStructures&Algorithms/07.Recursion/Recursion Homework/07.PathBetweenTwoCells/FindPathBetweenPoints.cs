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
        public bool[,] maze;

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
            maze = new bool[Maze.maze.Length, Maze.maze[0].Length];
            for (int i = 0; i < Maze.maze.Length; i++)
            {
                for (int j = 0; j < Maze.maze[i].Length; j++)
                {
                    maze[i, j] = Maze.maze[i][j] == ' ';
                }
            }

        }

        private Stack<MazeCell> route = new Stack<MazeCell>();

        bool RecursiveSolverDFS(MazeCell endCell)
        {

            bool routeFound = false;
            MazeCell currentCell = new MazeCell();
            currentCell.row = route.Peek().row;
            currentCell.col = route.Peek().col;

            if (currentCell.Equals(endCell))
            {
                return true;
            }

            currentCell.row = currentCell.row - 1;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                routeFound = RecursiveSolverDFS(endCell);
                if (routeFound)
                {
                    return true;
                }
                currentCell.HideCell();
                route.Pop();
            }

            currentCell.row = currentCell.row + 2;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                routeFound = RecursiveSolverDFS(endCell);
                if (routeFound)
                {
                    return true;
                }
                currentCell.HideCell();
                route.Pop();
            }

            currentCell.row = currentCell.row - 1;
            currentCell.col = currentCell.col - 1;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                routeFound = RecursiveSolverDFS(endCell);
                if (routeFound)
                {
                    return true;
                }
                currentCell.HideCell();
                route.Pop();
            }

            currentCell.col = currentCell.col + 2;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                routeFound = RecursiveSolverDFS(endCell);
                if (routeFound)
                {
                    return true;
                }
                currentCell.HideCell();
                route.Pop();
            }

            return routeFound;
        }

        public bool SolveMazeDFS(MazeCell startCell, MazeCell endCell)
        {
            foreach (var row in Maze.maze)
            {
                Console.WriteLine(row);
            }

            Console.SetCursorPosition(0, maze.GetLength(0) + 1);
            Console.WriteLine("Solving maze by depth-first search");
            Console.WriteLine("Press ENTER to find the route");
            Console.ForegroundColor = ConsoleColor.Yellow;
            endCell.ShowCell();
            startCell.ShowCell();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ReadLine();
            route.Push(startCell);
            bool success = RecursiveSolverDFS(endCell);

            Console.ForegroundColor = ConsoleColor.Yellow;
            startCell.ShowCell();
            endCell.ShowCell();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.SetCursorPosition(0, maze.GetLength(0));
//            Console.WriteLine(string.Join(", ", route));
            Console.WriteLine("Start: " + startCell + ", End: " + endCell);
            if (success)
            {
                Console.WriteLine("Route found");
            }
            else
            {
                Console.WriteLine("No route between points");
            }
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
            return success;
        }


        Queue<Stack<MazeCell>> queue = new Queue<Stack<MazeCell>>();

        public Stack<MazeCell> RecursiveSolverBFS(MazeCell endCell)
        {
            Stack<MazeCell> currentRoute;
            MazeCell currentCell;
            bool routeFound = false;
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
                    if (newCell.Equals(endCell))
                    {
                        return currentRoute;
                    }
                    queue.Enqueue(newRoute);
                }

                newRoute = new Stack<MazeCell>(currentRoute);
                newCell = new MazeCell(currentCell);
                newCell.row = currentCell.row + 1;
                if (IsFree(newCell) && !currentRoute.Contains(newCell))
                {
                    newRoute.Push(newCell);
                    newCell.ShowCell();
                    if (newCell.Equals(endCell))
                    {
                        return currentRoute;
                    }
                    queue.Enqueue(newRoute);
                }

                newRoute = new Stack<MazeCell>(currentRoute);
                newCell = new MazeCell(currentCell);
                newCell.col = currentCell.col - 1;
                if (IsFree(newCell) && !currentRoute.Contains(newCell))
                {
                    newRoute.Push(newCell);
                    newCell.ShowCell();
                    if (newCell.Equals(endCell))
                    {
                        return currentRoute;
                    }
                    queue.Enqueue(newRoute);
                }

                newRoute = new Stack<MazeCell>(currentRoute);
                newCell = new MazeCell(currentCell);
                newCell.col = currentCell.col + 1;
                if (IsFree(newCell) && !currentRoute.Contains(newCell))
                {
                    newRoute.Push(newCell);
                    newCell.ShowCell();
                    if (newCell.Equals(endCell))
                    {
                        return currentRoute;
                    }
                    queue.Enqueue(newRoute);
                }

            }
            return null;
        }

        public bool SolveMazeBFS(MazeCell startCell, MazeCell endCell)
        {
            Console.Clear();
            foreach (var row in Maze.maze)
            {
                Console.WriteLine(row);
            }
            Console.SetCursorPosition(0, maze.GetLength(0) + 1);
            Console.WriteLine("Solving same maze by breath-first search");
            Console.WriteLine("Press ENTER to find the route");
            Console.ForegroundColor = ConsoleColor.Yellow;
            endCell.ShowCell();
            startCell.ShowCell();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ReadLine();

            Stack<MazeCell> currentRoute = new Stack<MazeCell>();
            MazeCell currentCell = new MazeCell(startCell);
            currentRoute.Push(currentCell);
            queue.Enqueue(currentRoute);
            Stack<MazeCell> routeFound = RecursiveSolverBFS(endCell);
            Console.ForegroundColor = ConsoleColor.Yellow;
            startCell.ShowCell();
            endCell.ShowCell();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.SetCursorPosition(0, maze.GetLength(0));
//            Console.WriteLine(string.Join(", ", route));
            Console.WriteLine("Start: " + startCell + ", End: " + endCell);
            if (routeFound != null)
            {
                Console.WriteLine("Route found");
                Console.ForegroundColor = ConsoleColor.Green;
                while (routeFound.Count > 0)
                {
                    routeFound.Pop().ShowCell();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                startCell.ShowCell();
            }
            else
            {
                Console.WriteLine("No route between points");
            }
            Console.SetCursorPosition(0, maze.GetLength(0));
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
            return routeFound != null;
        }
    }



    class FindPathBetweenPoints
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 50;
            MazeSolver solver = new MazeSolver();
            solver.GenrateMaze();

            MazeCell startCell = new MazeCell();
            while (!solver.IsFree(startCell))
            {
                startCell.row = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));
                startCell.col = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));
            }

            MazeCell endCell = new MazeCell();
            while (!solver.IsFree(endCell))
            {
                endCell.row = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));
                endCell.col = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));
            }

            //            Console.WriteLine("Start:" + startCell + " End: " + endCell);
            solver.SolveMazeDFS(startCell, endCell);
            solver.SolveMazeBFS(startCell, endCell);
        }
    }
}

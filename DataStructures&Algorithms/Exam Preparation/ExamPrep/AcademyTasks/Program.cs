using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    class Problem
    {
        public int problemNo;
        public int depth;

        public Problem(int no, int d)
        {
            this.problemNo = no;
            this.depth = d;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] problems = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int thresold = int.Parse(Console.ReadLine());
            Queue<Problem> queue = new Queue<Problem>();
            Problem currentProblem = new Problem(0, 1);
            queue.Enqueue(currentProblem);
            while (queue.Count > 0)
            {
                currentProblem = queue.Dequeue();
                int cProblemNo = currentProblem.problemNo;
                if (cProblemNo + 1 >= problems.Length || Math.Abs(problems[cProblemNo] - problems[cProblemNo + 1]) >= thresold)
                {
                    break;
                }
                if (cProblemNo + 2 >= problems.Length || Math.Abs(problems[cProblemNo] - problems[cProblemNo + 2]) >= thresold)
                {
                    break;
                }
                queue.Enqueue(new Problem(cProblemNo + 1, currentProblem.depth + 1));
                queue.Enqueue(new Problem(cProblemNo + 2, currentProblem.depth + 1));
            }
            Console.WriteLine(currentProblem.depth);
        }
    }
}

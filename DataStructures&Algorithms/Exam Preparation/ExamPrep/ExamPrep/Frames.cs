using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
    class Frame
    {
        public Frame(int w, int h)
        {
            this.width = w;
            this.height = h;
        }
        public int width;
        public int height;

        public void Swap()
        {
            int tmp = this.height;
            this.height = this.width;
            this.width = tmp;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.width, this.height);
        }
    }

    class Frames
    {
        public static Frame[] frames;
        public static bool[] used;
        public static SortedSet<string> result = new SortedSet<string>();

        public static void Recursion(Stack<Frame> set, int depth)
        {
            int fl = frames.Length;
            if (depth == fl)
            {
                result.Add(string.Join(" | ", set));
                return;
            }
            for (int i = 0; i < fl; i++)
            {
                if (!used[i])
                {
                    set.Push(frames[i]);
                    used[i] = true;
                    Recursion(set, depth + 1);
                    frames[i].Swap();
                    Recursion(set, depth + 1);
                    frames[i].Swap();
                    used[i] = false;
                    set.Pop();
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            frames = new Frame[n];
            used = new bool[n];
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                frames[i] = new Frame(input[0], input[1]);
            }
            Recursion(new Stack<Frame>(), 0);
            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join("\n", result));
        }
    }
}

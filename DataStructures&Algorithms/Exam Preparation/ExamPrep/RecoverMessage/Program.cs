using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverMessage
{
    class Node : IComparable<Node>
    {
        public Node()
        {
            this.parents = new SortedSet<Node>();
            this.successors = new SortedSet<Node>();
        }

        public char ch;
        public SortedSet<Node> parents;
        public SortedSet<Node> successors;

        public int CompareTo(Node other)
        {
            return this.ch - other.ch;
        }
        public override string ToString()
        {
            return ch.ToString();
        }
    }

    class Program
    {
        public static SortedDictionary<char, Node> graph = new SortedDictionary<char, Node>();
        static void Main(string[] args)
        {

            // Input
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < input.Length; j++)
                {
                    if (!graph.ContainsKey(input[j]))
                    {
                        Node newNode = new Node();
                        newNode.ch = input[j];
                        graph.Add(input[j], newNode);
                    }
                    if (j > 0)
                    {
                        graph[input[j]].parents.Add(graph[input[j - 1]]);
                        graph[input[j - 1]].successors.Add(graph[input[j]]);
                    }
                }
            }

            // TopoSort
            List<Node> result = new List<Node>();
//            set.Add(graph.First(g => g.Value.parents.Count == 0).Value);
            while (graph.Count > 0)
            {
                Node currentNode = graph.First(g => g.Value.parents.Count == 0).Value;
                result.Add(currentNode);
                foreach (var child in currentNode.successors)
                {
                    child.parents.Remove(currentNode);
                }
                graph.Remove(currentNode.ch);
            }
            Console.WriteLine(string.Join("", result.Select(n => n.ch)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoAcademy
{
    class TvCompany
    {
        static Tuple<int, int, int>[] paths;
        static ISet<int> houses;

        static void Main()
        {
            ParseInput();

//            Console.WriteLine(string.Join(Environment.NewLine,
//                paths.Select(a => string.Format("[{0} {1} -> {2}]", a.Item1, a.Item2, a.Item3))));

            var allTrees = RepresendEachNodeAsTree();

            double result = FindMinimalCost(allTrees);

//            Console.WriteLine("\nMinimal cost for cable: " + result);
            Console.WriteLine(result);
        }

        static HashSet<ISet<int>> RepresendEachNodeAsTree()
        {
            var allTrees = new HashSet<ISet<int>>();

            // Represend each node as tree
            foreach (var node in houses)
            {
                var tree = new HashSet<int>();
                tree.Add(node);

                allTrees.Add(tree);
            }

            return allTrees;
        }

        static double FindMinimalCost(HashSet<ISet<int>> allTrees)
        {
            // Kruskal -> Sorting edges by their weight
            Array.Sort(paths, (a, b) => a.Item3.CompareTo(b.Item3));

            double result = 0;

            foreach (var path in paths)
            {
                var tree1 = allTrees.Where(tree => tree.Contains(path.Item1)).First();
                var tree2 = allTrees.Where(tree => tree.Contains(path.Item2)).First();

                // Elements are in same tree
                if (tree1.Equals(tree2)) continue;

                result += path.Item3;

                tree1.UnionWith(tree2);
                allTrees.Remove(tree2);

                // Small optimization
                if (allTrees.Count == 1) break;
            }

            return result;
        }

        static void ParseInput()
        {
            //string[] inputStr = { "9",
            //    "1 2 1",
            //    "1 4 4",
            //    "1 5 3",
            //    "2 4 4",
            //    "2 5 2",
            //    "4 5 4",
            //    "5 3 4",
            //    "5 6 7",
            //    "3 6 5" };
            int N = int.Parse(Console.ReadLine());
            paths = new Tuple<int, int, int>[N];
            houses = new HashSet<int>();

            for (int i = 1; i <= N; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                paths[i-1] = new Tuple<int, int, int>(input[0], input[1], input[2]);
                houses.Add(input[0]);
                houses.Add(input[1]);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FriendsOfPesho
{

    class Node
    {
        public Node(int nodeNo, int distance)
        {
            this.Number = nodeNo;
            this.Distance = distance;
        }

        public int Number { get; set; }

        public int Distance { get; set; }
    }

    class FriendsOfPesho
    {
        static List<Node>[] graph;
        static HashSet<int> hospitalNums;

        static void ParseInput()
        {
            string[] input = Console.ReadLine().Split(' ');
            int nodes = int.Parse(input[0]);
            int connections = int.Parse(input[1]);
            int hospitals = int.Parse(input[2]);

            graph = new List<Node>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Node>();
            }

            input = Console.ReadLine().Split(' ');
            hospitalNums = new HashSet<int>();
            for (int i = 0; i < hospitals; i++)
            {
                hospitalNums.Add(int.Parse(input[i])-1);
            }

            for (int i = 0; i < connections; i++)
            {
                input = Console.ReadLine().Split(' ');
                int from = int.Parse(input[0]) - 1;
                int to = int.Parse(input[1]) - 1;
                int distance = int.Parse(input[2]);
                graph[from].Add(new Node(to, distance));
                graph[to].Add(new Node(from, distance));
            }
        }

        static int FindMinimalSum()
        {
            int minDistance = int.MaxValue;

            foreach (var item in hospitalNums)
            {
                int currentMinDistance = 0;
                int[] currentDistances = FindMinimalDistance(item);
                for (int i = 0; i < currentDistances.Length; i++)
                {
                    if (!hospitalNums.Contains(i))
                    {
                        currentMinDistance += currentDistances[i];
                    }
                }
                if (currentMinDistance < minDistance)
                {
                    minDistance = currentMinDistance;
                }
            }
            return minDistance;
        }

        static int[] FindMinimalDistance(int source)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(new Node(source, 0));

            int[] distances = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
 
            distances[source] = 0;
            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();

                foreach (var neighbour in graph[currentNode.Number])
                {
                    int currentDistance = distances[currentNode.Number] + neighbour.Distance;

                    if (currentDistance < distances[neighbour.Number])
                    {
                        distances[neighbour.Number] = currentDistance;
                        queue.Enqueue(new Node(neighbour.Number, currentDistance));
                    }
                }
            }

            return distances;
        }

        static void Main()
        {
            ParseInput();
            var minDistance = FindMinimalSum();
            Console.WriteLine(minDistance);
        }
    }
}
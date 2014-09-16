using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndTraversal
{
    /* You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), 
     * each in the range (0..N-1). Example:
     * 2 4
     * 3 2
     * 5 0
     * 3 5
     * 5 6
     * 5 1
     * Write a program to read the tree and find:
     * a) the root node
     * b) all leaf nodes
     * c) all middle nodes
     * d) the longest path in the tree
     * e) * all paths in the tree with given sum S of their nodes
     * f) * all subtrees with given sum S of their nodes
     */

    class TreeTest
    {
        static void Main(string[] args)
        {
            MyTree<int> testTree = new MyTree<int>();
            testTree.AddChildOn(2, 4);
            testTree.AddChildOn(3, 2);
            testTree.AddChildOn(5, 0);
            testTree.AddChildOn(3, 5);
            testTree.AddChildOn(5, 6);
            testTree.AddChildOn(5, 1);
            testTree.AddChildOn(1, 7);

            //            testTree.AddChildOn(2, 5); // try to move part of tree - and IT'S WORK!

            if (!testTree.CheckTreeConsistency())
            {
                Console.WriteLine("Tree is not solid! Check connections again!");
                Environment.Exit(0);
            }

            // a) Find root node
            Console.WriteLine("Root element in tree is: {0}", testTree.root);

            //b) return all leafs
            Console.WriteLine("List of all leafs: {0}", String.Join(", ", testTree.leafs));

            //c) return all middles
            Console.WriteLine("List of all middles: {0}", String.Join(", ", testTree.middles));

            //d) return the longest path
            Console.WriteLine("Longest path: {0}", String.Join(", ", testTree.FindLongestPath));
        }
    }
}

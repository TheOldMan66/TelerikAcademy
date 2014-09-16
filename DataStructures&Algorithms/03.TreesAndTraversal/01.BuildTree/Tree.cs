using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndTraversal
{
    class MyTree<T>
    {
        private List<MyTreeNode<T>> roots = new List<MyTreeNode<T>>();

        public MyTree()
        {
        }

        private MyTreeNode<T> DFSFindNode(MyTreeNode<T> node, T searchValue)
        {
            if (node == null)
            {
                return null;
            }

            if (EqualityComparer<T>.Default.Equals(node.Value, searchValue))
            {
                return node;
            }

            MyTreeNode<T> childNode;
            foreach (var childs in node.Childs)
            {
                childNode = DFSFindNode(childs, searchValue);
                if (childNode != null)
                {
                    return childNode;
                }
            }
            return null;
        }

        public MyTreeNode<T> FindNode(T searchValue)
        {
            MyTreeNode<T> result;
            foreach (var item in roots)
            {
                result = DFSFindNode(item, searchValue);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public bool CheckTreeConsistency()
        {
            return roots.Count == 1;
        }

        public void AddChildOn(T parentElementValue, T valueToAdd)
        {
            MyTreeNode<T> parentNode = this.FindNode(parentElementValue);
            MyTreeNode<T> childNode = this.FindNode(valueToAdd);
            if (parentNode == null)
            {
                parentNode = new MyTreeNode<T>(parentElementValue);
                this.roots.Add(parentNode);
                if (childNode != null)
                {
                    if (this.roots.Contains(childNode))
                    {
                        this.roots.Remove(childNode);
                    }
                    childNode.ChangeParent(parentNode);
                }
                else
                {
                    parentNode.AddChild(valueToAdd);
                }
            }
            else
            {
                if (childNode != null)
                {
                    if (this.roots.Contains(childNode))
                    {
                        this.roots.Remove(childNode);
                    }
                    childNode.ChangeParent(parentNode);
                }
                else
                {
                    parentNode.AddChild(valueToAdd);
                }
            }
        }

        // a) - find root node
        public T root
        {
            get
            {
                return this.roots[0].Value;
            }
        }

        // b) - find all leaf nodes
        private List<T> GetAllLeafs(MyTreeNode<T> node, List<T> result)
        {
            if (node.Childs.Count > 0)
            {
                foreach (var childs in node.Childs)
                {
                    GetAllLeafs(childs, result);
                }
            }
            else
            {
                result.Add(node.Value);
            }

            return result;
        }

        public List<T> leafs
        {
            get
            {
                return GetAllLeafs(this.roots[0], new List<T>());
            }
        }

        // c) - find all middle nodes
        private List<T> GetMiddles(MyTreeNode<T> node, List<T> result)
        {
            if (node.Childs.Count > 0)
            {
                result.Add(node.Value);
                foreach (var childs in node.Childs)
                {
                    GetMiddles(childs, result);
                }
            }

            return result;
        }

        public List<T> middles
        {
            get
            {
                List<T> result = new List<T>();
                foreach (var childs in this.roots[0].Childs)
                {
                    GetMiddles(childs, result);
                }
                return result;
            }
        }

        // d) find longest path in the tree
        public void CalculatePath(MyTreeNode<T> currentNode, List<MyTreeNode<T>> currentPath, List<MyTreeNode<T>> maxPath, bool traverceParent)
        {
            if (!currentPath.Contains(currentNode))
            {
                currentPath.Add(currentNode);
                foreach (var node in currentNode.Childs)
                {
                    CalculatePath(node, currentPath, maxPath, traverceParent);
                }
                if (traverceParent && currentNode.Parent != null)
                {
                    CalculatePath(currentNode.Parent, currentPath, maxPath, traverceParent);
                }
                if (currentPath.Count > maxPath.Count)
                {
                    maxPath.Clear();
                    maxPath.AddRange(currentPath);
                }
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }

        public List<T> FindLongestPath
        {
            get
            {
                List<MyTreeNode<T>> maxPath = new List<MyTreeNode<T>>();
                List<MyTreeNode<T>> currentPath = new List<MyTreeNode<T>>();
                CalculatePath(this.roots[0], currentPath, maxPath, false);
                currentPath.Clear();
                CalculatePath(maxPath[maxPath.Count - 1], currentPath, maxPath, true);
                List<T> result = new List<T>();
                for (int i = 0; i < maxPath.Count; i++)
                {
                    result.Add(maxPath[i].Value);
                }
                return result;
            }
        }

        // d) find longest path in the tree
        public void CalculateSum(int sumToReach, MyTreeNode<T> currentNode, List<MyTreeNode<T>> currentPath, List<MyTreeNode<T>> maxPath, bool traverceParent)
        {
            if (!currentPath.Contains(currentNode))
            {
                currentPath.Add(currentNode);
                foreach (var node in currentNode.Childs)
                {
                    CalculateSum(sumToReach, node, currentPath, maxPath, traverceParent);
                }
                if (traverceParent && currentNode.Parent != null)
                {
                    CalculateSum(sumToReach, currentNode.Parent, currentPath, maxPath, traverceParent);
                }
                if (currentPath.Count > maxPath.Count)
                {
                    maxPath.Clear();
                    maxPath.AddRange(currentPath);
                }
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }

        public List<T> FindPathSWithSum(int sumToReach)
        {
            List<MyTreeNode<T>> maxPath = new List<MyTreeNode<T>>();
            List<MyTreeNode<T>> currentPath = new List<MyTreeNode<T>>();
            CalculateSum(sumToReach, this.roots[0], currentPath, maxPath, false);
            currentPath.Clear();
            CalculateSum(sumToReach, maxPath[maxPath.Count - 1], currentPath, maxPath, true);
            List<T> result = new List<T>();
            for (int i = 0; i < maxPath.Count; i++)
            {
                result.Add(maxPath[i].Value);
            }
            return result;
        }

    }
}

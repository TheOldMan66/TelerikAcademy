using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BinaryTree
{
    class TreeNode<T> where T : IComparable<T>
    {
        private T item;
        internal TreeNode<T> leftChild;
        internal TreeNode<T> rightChild;

        public T Value
        {
            get { return item; }
        }

        public TreeNode(T item)
        {
            this.item = item;
        }

        public int CompareTo(TreeNode<T> other)
        {
            return this.CompareTo(other.item);
        }

        public int CompareTo(T other)
        {
            return this.item.CompareTo(other);
        }
    }

    struct BinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        private void AddToPos(ref TreeNode<T> pos, T item)
        {
            if (pos == null)
            {
                pos = new TreeNode<T>(item);
                return;
            }
            if (pos.CompareTo(item) > 0)
                AddToPos(ref pos.leftChild, item);
            else if (pos.CompareTo(item) < 0)
                AddToPos(ref pos.rightChild, item);
            else
                return;
        }

        public void Add(T item)
        {
            AddToPos(ref this.root, item);
        }

        public bool Contains(T item)
        {
            TreeNode<T> currentPos = this.root;
            while (currentPos != null)
            {
                if (currentPos.CompareTo(item) == 0)
                    return true;
                if (currentPos.CompareTo(item) > 0)
                    currentPos = currentPos.leftChild;
                else
                    currentPos = currentPos.rightChild;
            }
            return false;
        }

        private bool RemoveAt(ref TreeNode<T> current, T item)
        {
            if (current == null) // no matching value found
                return false;
            if (current.CompareTo(item) > 0)
                return RemoveAt(ref current.leftChild, item);
            if (current.CompareTo(item) < 0)
                return RemoveAt(ref current.rightChild, item);
            if (current.leftChild == null)
                if (current.rightChild == null) // element has no childs
                    current = null;
                else
                    current = current.rightChild; // element have only right child
            else // element have left child 
                if (current.rightChild == null) // element have left child only
                    current = current.leftChild;
                else // element have left and right childs
                {
                    TreeNode<T> tempLeftChid = current.leftChild;
                    TreeNode<T> temp = current.rightChild;
                    while (temp.leftChild != null)
                        temp = temp.leftChild;
                    current = temp;
                    current.leftChild = tempLeftChid;
                }
            return true;
        }

        public bool Remove(T item)
        {
            return RemoveAt(ref this.root, item);
        }

    }

    class BinaryTreeTest
    {
        static void Main(string[] args)
        {
            BinaryTree<int> test = new BinaryTree<int>();
            test.Add(5);
            test.Add(3);
            test.Add(7);
            test.Add(4);
            test.Add(9);
            test.Add(1);
            test.Add(2);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} - {1}", i, test.Contains(i));
            }
            test.Remove(5);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} - {1}", i, test.Contains(i));
            }
        }
    }
}

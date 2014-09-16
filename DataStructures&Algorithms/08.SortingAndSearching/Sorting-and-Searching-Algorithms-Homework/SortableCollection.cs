namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                Console.Write(items[i]+ " ");
                if (items[i].CompareTo(item) == 0)
                {
                    Console.WriteLine();
                    return true;
                }
            }
            Console.WriteLine();
            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new MergeSorter<T>());
            int leftPointer = 0;
            int rightPoiner = this.items.Count - 1;
            while (leftPointer <= rightPoiner)
            {
                int middle = leftPointer + (rightPoiner - leftPointer) / 2;
                Console.Write(items[middle] + " ");
                if (items[middle].CompareTo(item) == 0)
                {
                    Console.WriteLine();
                    return true;
                }
                else if (items[middle].CompareTo(item) < 0)
                {
                    leftPointer = middle + 1;
                }
                else
                {
                    rightPoiner = middle - 1;
                }
            }
            Console.WriteLine();
            return false;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < items.Count; i++)
            {
                T tmp = items[i];
                int newPos = rnd.Next(0,items.Count);
                items[i] = items[newPos];
                items[newPos] = tmp;
            }
            // complexity is O(n) - every element is iterated only once.

        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}

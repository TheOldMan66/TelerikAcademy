namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {

        // I don't use extra memory, work only with indexes, so method is little messy... :)
        // but it's work, and is memory effective.
        private void RecursiveSort(IList<T> input, int leftIndex, int rightIndex)
        {
            if (rightIndex - leftIndex < 2)
            {
                return;
            }

            int pivot = leftIndex + (rightIndex - leftIndex) / 2;
            for (int i = leftIndex; i <= rightIndex; i++)
            {
                if (i == pivot)
                {
                    continue;
                }

                if (input[i].CompareTo(input[pivot]) < 0)
                {
                    input.Insert(leftIndex, input[i]);
                    input.RemoveAt(i + 1);
                    if (i > pivot) // adjusting pivot, because element is moved from right side to left side of pivot
                    {
                        pivot++;
                    }
                }
                else
                {
                    input.Insert(rightIndex, input[i]);
                    input.RemoveAt(i);
                    if (i < pivot) // adjusting pivot, because element is moved from left to right side of pivot
                    {
                        pivot--;
                    }
                }
            }

            RecursiveSort(input, leftIndex, pivot - 1);
            RecursiveSort(input, pivot + 1, rightIndex);
        }

        public void Sort(IList<T> collection)
        {
            RecursiveSort(collection, 0, collection.Count - 1);
        }

    }
}

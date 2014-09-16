namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    //    using System.Linq;
    //    using System.Text;
    //    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private void RecursiveMerge(IList<T> arr)
        {
            if (arr.Count < 2)
            {
                return;
            }
            // splitting
            int middle = arr.Count / 2;
            List<T> left = new List<T>(middle);
            List<T> right = new List<T>(arr.Count - middle);
            for (int i = 0; i < arr.Count; i++)
            {
                if (i < middle)
                {
                    left.Add(arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                }
            }
            RecursiveMerge(left);
            RecursiveMerge(right);

            // merging
            int leftPointer = 0;
            int rightPointer = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (leftPointer < left.Count)
                {
                    if (rightPointer < right.Count)
                    {
                        if (left[leftPointer].CompareTo(right[rightPointer]) < 0)
                        {
                            arr[i] = left[leftPointer];
                            leftPointer++;
                        }
                        else
                        {
                            arr[i] = right[rightPointer];
                            rightPointer++;
                        }
                    }
                    else
                    {
                        arr[i] = left[leftPointer];
                        leftPointer++;
                    }
                }
                else
                {
                    arr[i] = right[rightPointer];
                    rightPointer++;
                }
            }
        }

        public void Sort(IList<T> collection)
        {
            RecursiveMerge(collection);
        }
    }
}

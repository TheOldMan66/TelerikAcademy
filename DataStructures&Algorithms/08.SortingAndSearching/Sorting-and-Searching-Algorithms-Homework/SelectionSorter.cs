namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int minElementPos;
            int n = collection.Count();
            T swapSpace;

            for (int i = 0; i < n - 1; i++)
            {
                minElementPos = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (collection[j].CompareTo(collection[minElementPos]) < 0)
                    {
                        minElementPos = j;
                    }
                }
                if (minElementPos != i)
                {
                    swapSpace = collection[i];
                    collection[i] = collection[minElementPos];
                    collection[minElementPos] = swapSpace;
                }
            }
        }
    }
}

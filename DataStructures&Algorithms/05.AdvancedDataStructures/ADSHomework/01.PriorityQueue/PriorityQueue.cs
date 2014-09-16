
namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<V>
    {
        private List<KeyValuePair<int, V>> heap;

        public PriorityQueue()
        {
            heap = new List<KeyValuePair<int, V>>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.heap.Capacity;
            }
        }

        public void Clear()
        {
            this.heap.Clear();
        }

        public void Enqueue(V val, int priority)
        {
            KeyValuePair<int, V> item = new KeyValuePair<int, V>(priority, val);
            this.heap.Add(item);

            int childIndex = this.heap.Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (CompareKeys(parentIndex, childIndex) >= 0)
                {
                    break;
                }

                SwapElements(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        public V Dequeue()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            int lastIndex = this.heap.Count - 1;

            KeyValuePair<int, V> topItem = this.heap[0];
            this.heap[0] = this.heap[lastIndex];
            this.heap.RemoveAt(lastIndex);
            lastIndex--;

            int parentIndex = 0;
            while (true)
            {
                int leftIndex = 2 * parentIndex + 1;
                if (leftIndex > lastIndex)
                {
                    break;
                }

                int swapIndex = leftIndex;
                int rightIndex = leftIndex + 1;
                if (rightIndex <= lastIndex && CompareKeys(rightIndex, leftIndex) > 0)
                {
                    swapIndex = rightIndex;
                }

                if (CompareKeys(parentIndex, swapIndex) >= 0)
                {
                    break;
                }

                SwapElements(swapIndex, parentIndex);
                parentIndex = swapIndex;
            }

            return topItem.Value;
        }

        public V Peek()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            return this.heap[0].Value;
        }

        public V[] ToArray()
        {
            V[] result = new V[heap.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.heap[i].Value;
            }

            return result;
        }

        private void SwapElements(int first, int second)
        {
            KeyValuePair<int, V> swap = this.heap[first];
            this.heap[first] = this.heap[second];
            this.heap[second] = swap;
        }

        private int CompareKeys(int firstIndex, int secondIndex)
        {
            return this.heap[firstIndex].Key.CompareTo(this.heap[secondIndex].Key);
        }
    }

    class PriorityQueueTest
    {
        static void Main()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            queue.Enqueue("Peshko (priority 0)", 0);
            queue.Enqueue("Doncho (priority 1)", 1);
            queue.Enqueue("Looser (priority -5)", -5);
            queue.Enqueue("Goshko (priority 0)", 0);
            queue.Enqueue("Niki (priority 2)", 2);
            queue.Enqueue("Stamat (priority 0)", 0);
            queue.Enqueue("Ivaylo (priority 1)", 1);
            queue.Enqueue("Mariika (priority 0)", 0);

            Console.WriteLine("On the top of the queue is {0}", queue.Peek());
            Console.WriteLine();
            Console.WriteLine("All items in queue:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            //Console.WriteLine(string.Join("\n", queue.ToArray()));
        }
    }
}
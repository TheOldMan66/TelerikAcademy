using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
{
    class LinkedQueue<T>
    {
        private LinkedList<T> dataWarehouse;
        
        public LinkedQueue()
        {
            this.dataWarehouse = new LinkedList<T>();
        }

        public void Push(T element)
        {
            this.dataWarehouse.AddLast(element);
        }

        public T Pop()
        {
            if (this.dataWarehouse.Count == 0)
            {
                throw new NullReferenceException("Queue is empty, cannot pop.");
            }
            T element = this.dataWarehouse.First();
            this.dataWarehouse.RemoveFirst();
            return element;
        }

    }

    class LinkedQueueTest
    {
        static void Main(string[] args)
        {
            LinkedQueue<string> testQueue = new LinkedQueue<string>();
            testQueue.Push("Pesho");
            testQueue.Push("Gosho");
            testQueue.Push("Stamat");
            Console.WriteLine(testQueue.Pop());
            Console.WriteLine(testQueue.Pop());
            Console.WriteLine(testQueue.Pop());
        }
    }
}

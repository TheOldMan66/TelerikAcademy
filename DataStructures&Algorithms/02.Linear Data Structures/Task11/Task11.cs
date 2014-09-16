using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class LinkedList<T>
    {
        private class ListItem<T>
        {
            private ListItem<T> nextElement;
            public T value;

            public ListItem<T> Next
            {
                get
                {
                    return this.nextElement;
                }
                internal set
                {
                    this.nextElement = value;
                }
            }
        }

        private ListItem<T> firstElement;

        public T this[int pos]
        {
            get
            {
                int currentPos = 0;
                ListItem<T> currentItem = firstElement;
                while (currentPos != pos)
                {
                    if (currentItem == null)
                    {
                        throw new ArgumentOutOfRangeException("Index out of range.");
                    }
                    currentItem = currentItem.Next;
                    currentPos++;
                }

                return currentItem.value;
            }

            set
            {
                int currentPos = 0;
                ListItem<T> currentItem = firstElement;
                while (currentPos != pos)
                {
                    if (currentItem == null)
                    {
                        throw new ArgumentOutOfRangeException("Index out of range.");
                    }
                    currentItem = currentItem.Next;
                    currentPos++;
                }

                currentItem.value = value;
            }
        }

        public void Add(T elementToAdd)
        {
            if (firstElement == null)
            {
                firstElement = new ListItem<T>();
                firstElement.value = elementToAdd;
                return;
            }

            ListItem<T> currentElement = firstElement;
            while (currentElement.Next != null)
            {
                currentElement = currentElement.Next;
            }
            currentElement.Next = new ListItem<T>();
            currentElement.Next.value = elementToAdd;
        }

    }

    class LinkedListTest
    {
        static void Main(string[] args)
        {
            LinkedList<string> testStringLinkedList = new LinkedList<string>();
            testStringLinkedList.Add("Pesho");
            testStringLinkedList.Add("Gosho");
            Console.WriteLine(testStringLinkedList[0]);
            Console.WriteLine(testStringLinkedList[1]);
            LinkedList<int> testIntLinkedList = new LinkedList<int>();
            testIntLinkedList.Add(20);
            testIntLinkedList.Add(666);
            Console.WriteLine(testIntLinkedList[0]);
            Console.WriteLine(testIntLinkedList[1]);
        }
    }
}

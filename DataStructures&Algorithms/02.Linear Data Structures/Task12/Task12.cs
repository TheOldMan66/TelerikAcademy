using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class MyStack<T>
    {
        private int initialStackSize = 4;
        private T[] dataWarehouse;
        private int stackPointer;

        public MyStack()
        {
            this.dataWarehouse = new T[initialStackSize];
            this.stackPointer = 0;
        }

        public MyStack(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("Initial stack size cannot be smaller than 1.");
            }

            this.dataWarehouse = new T[capacity];
            this.stackPointer = 0;
        }

        private void DoubleWarehouseCapacity()
        {
            Array.Resize(ref this.dataWarehouse, this.dataWarehouse.Length * 2);
        }

        private void ShrinkWarehouseCapacity()
        {
            Array.Resize(ref this.dataWarehouse, this.dataWarehouse.Length / 2 + 1);
        }

        public void Push(T element)
        {
            this.dataWarehouse[stackPointer] = element;
            this.stackPointer++;
            if (this.stackPointer == this.dataWarehouse.Length)
            {
                this.DoubleWarehouseCapacity();
            }
        }

        public T Pop()
        {
            if (this.stackPointer== 0)
            {
                throw new NullReferenceException("Stack is empty, cannot pop");
            }
            this.stackPointer--;
            T elementToReturn = this.dataWarehouse[stackPointer];
            if (this.stackPointer < this.dataWarehouse.Length / 2)
            {
                this.ShrinkWarehouseCapacity();
            }
            return elementToReturn;
        }
    }

    class StackTest
    {
        static void Main(string[] args)
        {
            MyStack<string> testStack = new MyStack<string>();
            testStack.Push("Pesho");
            testStack.Push("Gosho");
            testStack.Push("Stamat");
            Console.WriteLine(testStack.Pop());
            Console.WriteLine(testStack.Pop());
            Console.WriteLine(testStack.Pop());

            // if uncommnet next line Null reference exception will be thrown
            //            Console.WriteLine(testStack.Pop());
        }
    }
}

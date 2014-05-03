using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_11.GenericList
{
    public class GenericList<T>
    {
        private int currentIndex;
        private T[] data;

        public GenericList()
            : this(4)
        {
        }

        public GenericList(int initialCapacity)
        {
            if (initialCapacity < 1)
                throw new ArgumentException("Invalid index value");
            data = new T[initialCapacity];
            currentIndex = 0;
        }

        public int Lenght()
        {
            return currentIndex;
        }

        private void ExtendArray()
        {
            if (data.Length > 2000000000)
                throw new OutOfMemoryException("Array size exceed maximum capacity");
            T[] newArray = new T[data.Length * 2];
            Array.Copy(data, newArray, data.Length);
            data = newArray;
        }
        public void Add(T element)
        {
            if (currentIndex == data.Length)
                ExtendArray();
            data[currentIndex] = element;
            currentIndex++;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > currentIndex)
                throw new IndexOutOfRangeException("Index is outisde array");
            if (currentIndex == data.Length)
                ExtendArray();
            if (index != currentIndex)
                Array.Copy(data, index, data, index + 1, data.Length - index - 1);
            data[index] = element;
            currentIndex++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > currentIndex)
                    throw new IndexOutOfRangeException("Index is outisde array");
                return data[index];
            }
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= currentIndex)
                throw new IndexOutOfRangeException("Index is outisde array");
            if (index != currentIndex)
                Array.Copy(data, index + 1, data, index, data.Length - index - 1);
            currentIndex--;
            if (currentIndex < data.Length / 2)
            {
                T[] newArray = new T[data.Length / 2];
                Array.Copy(data, newArray, data.Length / 2);
                data = newArray;
            }
        }
        public void Clear()
        {
            data = new T[4];
            currentIndex = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < currentIndex; i++)
                if (data[i].Equals(element))
                    return i;
            return -1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < currentIndex; i++)
                sb.Append(data[i] + ", ");
            if (sb.Length > 2)
                sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
        public T Max<T>() where T : IComparable<T>, IComparable
        {
            T temp = (T)(object) data[0];
            for (int i = 1; i < currentIndex; i++)
            {
                if (temp.CompareTo(data[i]) < 0)
                    temp = (T)(object) data[i];
            }
            return temp;
        }

        public T Min<T>() where T : IComparable<T>, IComparable
        {
            T temp = (T)(object)data[0];
            for (int i = 1; i < currentIndex; i++)
            {
                if (temp.CompareTo(data[i]) > 0)
                    temp = (T)(object)data[i];
            }
            return temp;
        }

    }


    class GenericTest
    {
        static void Main(string[] args)
        {
            GenericList<string> strArr = new GenericList<string>();
            strArr.Add("1");
            strArr.Add("2");
            strArr.Add("3");
            strArr.Add("4");
            strArr.Add("5");

            Console.WriteLine("Initial array");
            for (int i = 0; i < strArr.Lenght(); i++)
                Console.Write(strArr[i] + ", ");
            Console.WriteLine();
            
            strArr.InsertAt(2, "Inserted");
            Console.WriteLine("Insert one element");
            for (int i = 0; i < strArr.Lenght(); i++)
                Console.Write(strArr[i] + ", ");
            Console.WriteLine();

            Console.WriteLine("Remove one element");
            strArr.Remove(4);
            for (int i = 0; i < strArr.Lenght(); i++)
                Console.Write(strArr[i] + ", ");
            Console.WriteLine();

            Console.WriteLine("Find minimal value");
            Console.WriteLine(strArr.Min<string>());
        }
    }
}
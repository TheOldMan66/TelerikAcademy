using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Bit64Test
{
    class Bit64 : IEnumerable<int>, IComparable<Bit64>
    {
        private ulong container;


        public Bit64(ulong initValue = 0)
        {
            container = initValue;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 64)
                    throw new IndexOutOfRangeException();
                return (container & 1U << index) > 0 ? 1 : 0;
            }
            set
            {
                if (value == 1)
                    container = container | (1U << index);
                else if (value == 0)
                    container = container & (~(1U << index));
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public ulong GetAsUlong()
        {
            return this.container;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return (container & 1U << i) > 0 ? 1 : 0;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (obj is ulong)
                return (ulong)obj == this.container;
            else
                throw new ArgumentException("Invalid type.");
        }

        public override int GetHashCode()
        {
            return container.GetHashCode();
        }

        public static bool operator == (Bit64 first, Bit64 second)
        {
            return first.container == second.container;
        }
        public static bool operator !=(Bit64 first, Bit64 second)
        {
            return first.container != second.container;
        }


        public int CompareTo(Bit64 other)
        {
            return container.CompareTo(other.container);
        }
    }


    class Bit64Test
    {
        static void Main(string[] args)
        {
            Bit64 test = new Bit64(100000);

            foreach (var bit in test)
                Console.Write(bit);
            Console.WriteLine();

            for (int i = 0; i < 64; i++)
                Console.Write(test[i]);
            Console.WriteLine();

            Bit64[] arr = new Bit64[5];
            arr[0] = new Bit64(5);
            arr[1] = new Bit64(50);
            arr[2] = new Bit64(256);
            arr[3] = new Bit64(22);
            arr[4] = new Bit64();
            arr[0][45] = 1;
            arr[1][10] = 1;
            arr[4][63] = 1;
            arr[2][8] = 0;
            Array.Sort(arr);
            foreach (Bit64 item in arr)
            {
                Console.WriteLine(item.GetAsUlong());
            }

            Bit64 first = new Bit64(10);
            Bit64 second = first;
            Console.WriteLine("{0} = {1}? {2}",first.GetAsUlong(), second.GetAsUlong(),first==second);
            second = new Bit64(10);
            Console.WriteLine("{0} = {1}? {2}", first.GetAsUlong(), second.GetAsUlong(), first == second);
            second = new Bit64(100);
            Console.WriteLine("{0} = {1}? {2}", first.GetAsUlong(), second.GetAsUlong(), first == second);
            Console.WriteLine("{0} != {1}? {2}", first.GetAsUlong(), second.GetAsUlong(), first != second);

        }
    }
}

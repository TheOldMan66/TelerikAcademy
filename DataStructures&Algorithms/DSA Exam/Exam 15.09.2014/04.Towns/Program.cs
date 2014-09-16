using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Towns
{
    class Program
    {
        class Element //: IEquatable<Element>
        {
            public Element(int val, int dep)
            {
                this.values = val;
                this.depth = dep;
            }

            public int values;
            public int depth;

            public void Swap(int from, int len)
            {
                char[] arr;
                arr = this.values.ToString().ToCharArray();
                Array.Reverse(arr, from, len);
                this.values = int.Parse(string.Join("",arr));
            }
        }

        static void Main(string[] args)
        {
            int numOfDigits = int.Parse(Console.ReadLine());
            string[] numbers = Console.ReadLine().Split(' ');
            int sequenceLenght = int.Parse(Console.ReadLine());
            int elementToFind = int.Parse(string.Join("", numbers));
            Array.Sort(numbers);
            Element element = new Element(int.Parse(string.Join("", numbers)),0);

            Queue<Element> q = new Queue<Element>();
            HashSet<int> set = new HashSet<int>();
            q.Enqueue(element);
            bool SolutionFound = false;
            while (q.Count > 0)
            {
                element = q.Dequeue();
                if (element.values == elementToFind) // Equals(elementToFind))
                {
                    SolutionFound = true;
                    break;
                }
                for (int i = 0; i <= numOfDigits - sequenceLenght; i++)
                {
                    Element newElement = new Element(element.values, element.depth + 1);
                    newElement.Swap(i, sequenceLenght);
                    if (!set.Contains(newElement.values))
                    {
                        q.Enqueue(newElement);
                        set.Add(newElement.values);
                    }
                }
            }
            if (!SolutionFound)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(element.depth);
            }
        }
    }
}

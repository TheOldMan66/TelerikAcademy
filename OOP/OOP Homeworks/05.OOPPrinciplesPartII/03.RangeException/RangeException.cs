using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RangeException
{
    [Serializable]
    public class InvalidRangeException<T> : ApplicationException where T : IComparable
    {
        private T minValue;
        private T maxValue;
        public InvalidRangeException()
            : base()
        {
            Console.WriteLine("Invalid range exception.");
        }
        public InvalidRangeException(string message, T min, T max)
            : base()
        {
            Console.Write("Invalid {0} argument. Allowed values are {1} - {2}.", message, min, max);
        }
    }
}

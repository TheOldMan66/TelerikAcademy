using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PhoneBook
{
    class PhoneRecord : IEquatable<PhoneRecord>
    {
        private string name;
        private string town;
        private string phone;

        public PhoneRecord(string name, string town, string phone)
        {
            this.name = name;
            this.town = town;
            this.phone = phone;
        }

        public bool Equals(PhoneRecord other)
        {
            bool isEqual = string.IsNullOrWhiteSpace(this.name) || other.name.ToLower().Contains(this.name.ToLower());
            isEqual = isEqual && (string.IsNullOrWhiteSpace(this.town) || this.town.ToLower() == other.town.ToLower());
            isEqual = isEqual && (string.IsNullOrWhiteSpace(this.phone) || this.phone == other.phone);
            return isEqual;
        }

        public override string ToString()
        {
            return String.Format("Name: {0,-30} Town: {1,-10} Phone: {2}",this.name, this.town, this.phone);
        }
    }

    class PhoneBook
    {
        private List<PhoneRecord> container = new List<PhoneRecord>();

        public void Add(string name, string town, string phone)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(town) || string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Invalid user data");
            }

            PhoneRecord record = new PhoneRecord(name, town, phone);
            container.Add(record);
        }

        public List<PhoneRecord> Find(string name="", string town = "", string phone= "")
        {
            List<PhoneRecord> result = new List<PhoneRecord>();
            PhoneRecord recordToFind = new PhoneRecord(name,town,phone);
            foreach (PhoneRecord record in container)
            {
                if (recordToFind.Equals(record))
                {
                    result.Add(record);
                }
            }
            return result;
        }

    }

    class PhonebookTest
    {
        static void Main(string[] args)
        {
            PhoneBook book = new PhoneBook();
            book.Add("Mimi Shmatkata", "Plovdiv", "0888 12 34 56");
            book.Add("Kireto", "varna", "052 23 45 67");
            book.Add("Daniela Ivanova Petrova", "Karnobat", "0899 999 888");
            book.Add("bat Gencho", "Sofia", "02 76 54 32");
            book.Add("Doncho Minkov", "Vidin", "123 25 67 89");
            book.Add("Svetlin Nakov", "Kaspichan", "544 543 214");
            book.Add("Niki Kostov", "Vidin", "437 3434234");

            Console.WriteLine("Search Result 1: ");
            Console.WriteLine(string.Join("\n",book.Find("kov"))); // by part of name

            Console.WriteLine("\nSearch Result 2: ");
            Console.WriteLine(string.Join("\n", book.Find("", "Vidin"))); // by town

            Console.WriteLine("\nSearch Result 3: ");
            Console.WriteLine(string.Join("\n", book.Find("kov", "Vidin"))); // by part of name and town
        }
    }
}

// P.S. I don't understand why this homework is included here... It is for C# part 2 ...  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        class Student : IComparable<Student>
        {
            private string firstName;
            private string lastName;
            public Student(string fn, string ln)
            {
                this.firstName = fn;
                this.lastName = ln;
            }


            public string Name
            {
                get
                {
                    return this.firstName + " " + this.lastName;
                }
            }

            public int CompareTo(Student other)
            {
                return (this.lastName + this.firstName).CompareTo(other.lastName + other.firstName);
            }
        }

        class School
        {
            SortedDictionary<string, SortedSet<Student>> courses = new SortedDictionary<string, SortedSet<Student>>();

            public School()
            {
                this.courses = new SortedDictionary<string, SortedSet<Student>>();
            }

            public void AddStudent(string course, Student student)
            {
                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new SortedSet<Student>());
                }
                courses[course].Add(student);
            }

            public IEnumerable<string> GetCourses()
            {
                return courses.Keys;
            }
            public IEnumerable<string> GetStudentsInCourse(string course)
            {
                if (!courses.ContainsKey(course))
                {
                    return new List<string>();
                }
                return courses[course].Select(student => student.Name).ToList();
            }
        }

        static void Main(string[] args)
        {
            School school = new School();
            school.AddStudent("C#", new Student("Kiril", "Ivanov"));
            school.AddStudent("SQL", new Student("Stefka", "Nikolova"));
            school.AddStudent("JAVA", new Student("Stela", "Mineva"));
            school.AddStudent("C#", new Student("Milena", "Petrova"));
            school.AddStudent("C#", new Student("Ivan", "Grigorov"));
            school.AddStudent("SQL", new Student("Ivan", "Kolev"));

            foreach (var course in school.GetCourses())
            {
                Console.Write(course + ": ");
                Console.WriteLine(string.Join(", ",school.GetStudentsInCourse(course)));
            }
        }
    }
}

// Sorry, no time for high quality code. I promise to place classes in separate files nex time :)
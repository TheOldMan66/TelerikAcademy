using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05.StudentsManipulation
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Student(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }
    }
    class StudentsDemo
    {
        static void InitilaizeStudents(List<Student> students)
        {
            students.Add(new Student("Petar", "Stoyanov", 22));
            students.Add(new Student("Nikolay", "Vasilev", 16));
            students.Add(new Student("Yanko", "Petrov", 22));
            students.Add(new Student("Stefan", "Petov", 18));
            students.Add(new Student("Ivan", "Stoyanov", 26));
            students.Add(new Student("Ivan", "Petov", 18));
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            InitilaizeStudents(students);

            Console.WriteLine("List of all students:");
            foreach (Student student in students)
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Age);
            Console.WriteLine();

            /* TASK 3: Write a method that from a given array of students finds all students whose first name 
             * is before its last name alphabetically. Use LINQ query operators. */
            var selectedStudents =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            Console.WriteLine("List of students whose first name is before last name:");
            foreach (Student student in selectedStudents)
                Console.WriteLine(student.FirstName + " " + student.LastName);
            Console.WriteLine();

            /* TASK 4: Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.*/
            selectedStudents =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;
            Console.WriteLine("List of students wiht age between 18 and 24:");
            foreach (Student student in selectedStudents)
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Age);
            Console.WriteLine();

            /* TASK 5 Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
             * by first name and last name in descending order... */
            selectedStudents = students.OrderBy(name => name.FirstName).ThenBy(name => name.LastName);
            Console.WriteLine("List of students sorted by first name then by last name:");
            foreach (Student student in selectedStudents)
                Console.WriteLine(student.FirstName + " " + student.LastName);
            Console.WriteLine();

            /* TASK 5 ... Rewrite the same with LINQ. */
            selectedStudents =
                from student in students
                orderby student.FirstName, student.LastName
                select student;
            Console.WriteLine("List of students sorted by first name then by last name:");
            foreach (Student student in selectedStudents)
                Console.WriteLine(student.FirstName + " " + student.LastName);
            Console.WriteLine();
        }
    }
}

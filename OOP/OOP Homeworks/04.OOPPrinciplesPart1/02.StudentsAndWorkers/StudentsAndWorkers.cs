using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{

    /* Define abstract class Human with first name and last name. Define new class Student which is derived from Human 
     * and has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay 
     * and method MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and 
     * properties for this hierarchy. Initialize a list of 10 students and sort them by grade in ascending order 
     * (use LINQ or OrderBy() extension method). Initialize a list of 10 workers and sort them by money per hour in 
     * descending order. Merge the lists and sort them by first name and last name. */
    abstract class Human
    {
        //Define abstract class Human with first name and last name.
        private string firstName;
        private string lastName;

        public Human(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }

        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }

        public string Name()
        {
            return this.firstName + " " + this.lastName;
        }

    }

    class Student : Human
    {
       // Define new class Student which is derived from Human 
       // and has new field – grade.

        private float grade;
        public Student(string fname, string lName, float grade)
            : base(fname, lName)
        {
            this.Grade = grade;
        }
        public float Grade
        {
            get { return this.grade; }
            set
            {
                if (value < 2.0 || value > 6.0)
                    throw new ArgumentOutOfRangeException("Invalid grade");
                this.grade = value;
            }
        }
        public override string ToString()
        {
            return "Name: " + Name() + " Grade: " + Grade.ToString("0.00");
        }
    }

    class Worker : Human
    {
       /* Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay 
        * and method MoneyPerHour() that returns money earned by hour by the worker. */

        private float workHoursPerDay;
        private decimal weekSalary;
        private decimal hourSalary;

        private void CalcHourSalary()
        {
            this.hourSalary = this.weekSalary / 5.0M / (decimal)this.WorkHoursPerDay;
        }

        public Worker(string fname, string lName, float workHours, decimal salary)
            : base(fname, lName)
        {
            this.WorkHoursPerDay = workHours;
            this.WeekSalary = salary;
            CalcHourSalary();
        }
        public float WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0 || value > 16.0)
                    throw new ArgumentOutOfRangeException("Invalid value for work hours");
                this.workHoursPerDay = value;
                CalcHourSalary();
            }
        }
        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Invalid value for week salary");
                this.weekSalary = value;
                CalcHourSalary();
            }
        }
        public decimal HourSalary
        {
            get { return this.hourSalary; }
        }

        public override string ToString()
        {
            return "Name: " + Name() + string.Format(" W.h./day: {0,4:#0.0}", workHoursPerDay) +
                                       string.Format(" Week salary :{0,6:#0.00}", WeekSalary) +
                                       string.Format(" Hour salary : {0,4:#0.00}", HourSalary);
        }
    }


    class StudentsAndWorkersDemo
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

           /* Initialize a list of 10 students and sort them by grade in ascending order 
            * (use LINQ or OrderBy() extension method).  */

            List<Student> students = new List<Student>(10);
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("Student", "No " + rnd.Next(), (float)(rnd.NextDouble() * 4 + 2.001d)));
            }
            var selectedStudents =
                from student in students
                orderby student.Grade
                select student;
            Console.WriteLine("Students, sorted by grade:");
            foreach (Student st in selectedStudents)
            {
                Console.WriteLine(st);
            }

            /* Initialize a list of 10 workers and sort them by money per hour in 
             * descending order. */

            List<Worker> workers = new List<Worker>(10);
            for (int i = 0; i < 10; i++)
            {
                workers.Add(new Worker("Worker", "No " + rnd.Next(), (float)(rnd.NextDouble() * 12 + 1.001d), Convert.ToDecimal(rnd.Next(10, 100) + 1)));
            }
            var sortedWorkers = workers.OrderByDescending(w => w.HourSalary);
            Console.WriteLine("workers sorted by hours salary:");
            foreach (Worker wo in sortedWorkers)
            {
                Console.WriteLine(wo);
            }

            /*  Merge the lists and sort them by first name and last name. */
            List<Human> people = new List<Human>();
            people.AddRange(students);
            people.AddRange(workers);
            var sortedPeoples =
                from person in people
                orderby person.FirstName, person.LastName
                select person;
            Console.WriteLine("All peoples sorted by first and last name:");
            foreach (Human h in sortedPeoples)
            {
                Console.WriteLine(h);
            }

        }
    }
}
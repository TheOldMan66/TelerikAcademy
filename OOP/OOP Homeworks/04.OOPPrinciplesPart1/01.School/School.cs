using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{

    /* We are given a school. In the school there are classes of students. Each class has a set of teachers. 
     * Each teacher teaches a set of disciplines. Students have name and unique class number. 
     * Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and 
     * number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines 
     * could have optional comments (free text block).
	 * Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate 
     * their fields, define the class hierarchy and create a class diagram with Visual Studio */

    public class Person
    {
        private string name;
        private string comment;
        public Person(string name, string comment = "")
        {
            this.Name = name;
            this.Comment = comment;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public string Comment
        {
            get { return comment; }
            private set { comment = value; }
        }
    }

    class Student : Person
    {
        private int studentNumber;
        private List<Discipline> studiedDisciplines;

        public Student(string name, int classNumber, string comment = "")
            : base(name, comment)
        {
            this.studentNumber = classNumber;
            studiedDisciplines = new List<Discipline>();
        }
        public int ClassNumber
        {
            get { return studentNumber; }
            private set { studentNumber = value; }
        }
        // TODO : sign in and sign out from courses
    }

    class Teacher : Person
    {
        private List<Discipline> lecturedDisciplines;
        public Teacher(string name, string comment = "")
            : base(name, comment)
        {
            lecturedDisciplines = new List<Discipline>();
        }
        //TODO: add or remove lecturing courses
    }

    class SchoolClass
    {
        private string description;
        private List<Student> students;
        private string comment;
        public SchoolClass(string descr, string comment = "")
        {
            this.Description = descr;
            students = new List<Student>();
            this.comment = comment;
        }
        public string Description
        {
            get { return description; }
            private set { description = value; }
        }
        public List<Student> Students
        {
            get { return students; }
        }
        public string Comment
        {
            get { return comment; }
            private set { comment = value; }
        }
        //TODO: add or remove students form class
    }

    class Discipline
    {
        private string name;
        private int numOfLectures;
        private int numOfExercises;
        private string comment;

        public Discipline(string name, int numOfLectures, int numOfExercises, string comment = "")
        {
            this.Name = name;
            this.NumOfLectures = numOfLectures;
            this.NumOfExercises = numOfExercises;
            this.Comment = comment;
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int NumOfLectures
        {
            get { return numOfLectures; }
            private set { numOfLectures = value; }
        }
        public int NumOfExercises
        {
            get { return numOfExercises; }
            private set { numOfExercises = value; }
        }
        public string Comment
        {
            get { return comment; }
            private set { this.comment = value; }
        }
    }

    class SchoolDemo
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Pesho", 1));
            students.Add(new Student("Gosho", 2, "from Plovdiv"));
            students.Add(new Student("Toshko", 3, "from Kaspichan"));
            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(new Teacher("Nakov"));
            teachers.Add(new Teacher("Doncho"));
            teachers.Add(new Teacher("Niki"));
            List<SchoolClass> classes = new List<SchoolClass>();
            classes.Add(new SchoolClass("Winter selection"));
            classes.Add(new SchoolClass("Autumn selection"));
            classes.Add(new SchoolClass("Free online courses"));
            List<Discipline> disciplines = new List<Discipline>();
            disciplines.Add(new Discipline("C# part 1", 10, 1));
            disciplines.Add(new Discipline("C# part 2", 12, 1));
            disciplines.Add(new Discipline("OOP basics", 8, 1, "Active"));

        }
    }
}

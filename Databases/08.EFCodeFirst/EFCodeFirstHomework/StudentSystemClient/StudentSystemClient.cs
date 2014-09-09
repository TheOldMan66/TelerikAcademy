namespace StudentSystemClient
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    //    using System.Data.Entity.Validation;
    using System.Data;
    using System.Collections.Generic;
    using StudentSystem.Data;
    using StudentSystem.Model;

    class StudentSystemClient
    {
        public static string[] firstNames = new string[] { "Ivan", "Pesho", "Gosho", "Stamat", "Stoyan" };
        public static string[] lastNames = new string[] { "Ivanov", "Petrov", "Georgiev", "Stamatov", "Stoyanov" };
        public static string[] crs = new string[] { "C#", "Javascript", "HTML&CSS", "Databases", "Data structures & algorythms" };
        public static string[] descr = new string[] { "Most exciting technology ever", "Hard course", "Piece of cake", "Most useless course", "For advanced users only" };
        public static string[] hwNames = new string[] { "Homework 1", "Homework 2", "Endless homework", "Copy/Paste-d homework", "No homework" };

        static Random rnd = new Random();

        static void Main()
        {
            using (var db = new StudentSystemDBContext())
            {
//                goto cursor;

                for (int i = 0; i < 20; i++)
                {
                    var student = new Student() { Name = firstNames[rnd.Next(5)] + " " + lastNames[rnd.Next(5)], Number = rnd.Next(20) + 1 };
                    db.Students.Add(student);
                }
                db.SaveChanges();

                for (int i = 0; i < 10; i++)
                {
                    var course = new Course() { Name = crs[rnd.Next(5)], Description = descr[rnd.Next(5)] };
                    var randomStudents = db.Students.OrderBy(r => Guid.NewGuid()).Take(5); // get 5 random students.
                    foreach (var student in randomStudents)
                    {
                        if (!course.Students.Select(n => n.Name).Contains(student.Name))
                        {
                            course.Students.Add(student);                            
                        }
                    }

                    db.Courses.Add(course);
                }

                db.SaveChanges();

                for (int i = 0; i < 20; i++)
                {
                    var homework = new Homework() { 
                        Content = hwNames[rnd.Next(5)], 
                        Course = db.Courses.OrderBy(r => Guid.NewGuid()).First(), 
                        Student = db.Students.OrderBy(r => Guid.NewGuid()).First(), 
                        TimeSend = DateTime.Now 
                    };

                    db.Homeworks.Add(homework);
                }
                db.SaveChanges();

            cursor:

                Console.Write("Get random student from database: ");
                var randomStudent = db.Students.OrderBy(r => Guid.NewGuid()).First();
                Console.WriteLine("Name: {0}, Number: {1}",randomStudent.Name,randomStudent.Number);
                Console.WriteLine("Courses for this student:");
                foreach (var course in randomStudent.Courses)
                {
                    Console.WriteLine("  - {0} - > {1}",course.Name,course.Description);
                }
                if (randomStudent.Courses.Count > 0)
                {
                    var course = randomStudent.Courses.First();
                    Console.WriteLine("Students in course {0}",course.Name);
                    foreach (var student in course.Students)
                    {
                        Console.WriteLine(student.Name);                                            
                    }
                }
            }
        }
    }
}

// Нямам атрибути, тъй като EF сам си се оправи със структурата на данните. 
// Мога да си изсмуча някакви ограничения от пръстите ... но просто не виждам смисъл, а и няма време.
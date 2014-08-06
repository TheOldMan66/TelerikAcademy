using System;
using System.Collections.Generic;

namespace School
{
    public class Course : IEquatable<Course>
    {
        private List<Student> students;
        private int maxNumOfStudents = 30;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            students = new List<Student>();

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be empty");
                }
                this.name = value;
            }

        }

        public List<Student> Students
        {
            get
            {
                return students;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Cannot add null student in course");
            }
            if (students.Contains(student)) 
            {
                throw new ArgumentException("Student is already signed for this course");
            }
            if (students.Count == maxNumOfStudents)
            {
                throw new OverflowException("Course limit is reached - cannot add more students");
            }
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (students.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove student - course list is empty");
            }
            if (student == null)
            {
                throw new ArgumentNullException("Cannot remove null student in course");
            }
            if (!students.Contains(student))
            {
                throw new ArgumentException("Cannot remove student - its not in the course list");
            }
            students.Remove(student);
        }

        public bool Equals(Course other)
        {
            return this.Name == other.Name;
        }
    }
}
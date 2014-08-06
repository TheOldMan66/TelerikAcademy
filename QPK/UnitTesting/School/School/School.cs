using System;
using System.Collections.Generic;
namespace School
{
    public class School 
    {
        private List<Course> courses;
        private List<Student> students;

        public School()
        {
            courses = new List<Course>();
            students = new List<Student>();
        }

        public List<Course> Courses
        {
            get
            {
                return courses;
            }
        }

        public List<Student> Students
        {
            get
            {
                return students;
            }
        }

        public void SignInNewStudent(Student student)
        {
            if (students.Contains(student))
            {
                throw new ArgumentException("Cannot sign in one student twice");                                
            }
            students.Add(student);

        }

        public void SignOutStudent(Student student)
        {
            if (!students.Contains(student))
            {
                throw new ArgumentException("This student is not signed for the school");
            }
            foreach (Course course in courses)
            {
                if (course.Students.Contains(student))
                {
                    throw new ArgumentException("Student is signed for course. Sign out form course first");
                }
            }
            students.Add(student);

        }

        public void CreateNewCourse(Course course)
        {
            if (courses.Contains(course))
            {
                throw new ArgumentException("Cannot sign in one student twice");
            }
            courses.Add(course);
        }

        //public void AddStudentToCourse(Student student, Course course)
        //{
        //    if (student == null)
        //    {
        //        throw new ArgumentNullException("Cannot add null student to course");                
        //    }
        //    if (course == null)
        //    {
        //        throw new ArgumentNullException("Cannot add student to null course");
        //    }
        //    course.AddStudent(student);
        //}
        //public void RemoveStudentToCourse(Student student, Course course)
        //{
        //    if (student == null)
        //    {
        //        throw new ArgumentNullException("Cannot add null student to course");
        //    }
        //    if (course == null)
        //    {
        //        throw new ArgumentNullException("Cannot add student to null course");
        //    }
        //    course.RemoveStudent(student);
        //}
    }
}

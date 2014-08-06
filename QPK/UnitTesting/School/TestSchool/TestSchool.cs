using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void correctStudentCreation()
        {
            Student testStudent = new Student("Pesho", 20000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void createStudentWithSmallNumber()
        {
            Student testStudent = new Student("Pesho", 9);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void createStudentWithBigNumber()
        {
            Student testStudent = new Student("Pesho", 123456);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void createStudentWithNegativeNumber()
        {
            Student testStudent = new Student("Pesho", -123456);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void createStudentWithZeroNumber()
        {
            Student testStudent = new Student("Pesho", 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void createStudentWithEmptyName()
        {
            Student testStudent = new Student("", 45678);
        }

        [TestMethod]
        public void checkStoredName()
        {
            Student testStudent = new Student("Test Student", 45678);
            Assert.AreEqual(testStudent.Name, "Test Student", "Stored student name is not correct");
        }
        [TestMethod]
        public void checkStoredNumber()
        {
            Student testStudent = new Student("Test Student", 45678);
            Assert.AreEqual(testStudent.Number, 45678, "Stored student number is not correct");
        }
    }

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void correctCourseCreation()
        {
            Course course = new Course("Course");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void incorrectCourseCreation()
        {
            Course course = new Course("");
        }

        [TestMethod]
        public void fillCourseWithStudents()
        {
            Course course = new Course("Course");
            for (int i = 0; i < 30; i++)
            {
                Student testStudent = new Student("Pesho" + i, 20000 + i);
                course.AddStudent(testStudent);
            }
        }

        [TestMethod]
        public void add30AndRemove30()
        {
            Course course = new Course("Course");
            for (int i = 0; i < 30; i++)
            {
                Student testStudent = new Student("Pesho" + i, 20000 + i);
                course.AddStudent(testStudent);
            }
            for (int i = 0; i < 30; i++)
            {
                Student testStudent = new Student("Pesho" + i, 20000 + i);
                course.RemoveStudent(testStudent);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void add31Students()
        {
            Course course = new Course("Course");
            for (int i = 0; i < 31; i++)
            {
                Student testStudent = new Student("Pesho" + i, 20000 + i);
                course.AddStudent(testStudent);
            }
        }

        [TestMethod]
        public void checkStudentsConsistency()
        {
            Course course = new Course("Course");
            Student[] students = new Student[30];
            for (int i = 0; i < 30; i++)
            {
                students[i] = new Student("Pesho" + i, 20000 + i);
                course.AddStudent(students[i]);
            }

            for (int i = 0; i < 30; i++)
            {
                Assert.IsTrue(course.Students.Contains(students[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void removeNonSignedStudent()
        {
            Course course = new Course("Course");
            Student testStudent = new Student("Pesho", 20000);
            course.RemoveStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addSameStudentTwice()
        {
            Course course = new Course("Course");
            Student testStudent = new Student("Pesho", 20000);
            course.AddStudent(testStudent);
            course.AddStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void removeSameStudentTwice()
        {
            Course course = new Course("Course");
            Student testStudent = new Student("Pesho", 20000);
            course.AddStudent(testStudent);
            course.RemoveStudent(testStudent);
            course.RemoveStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void addNullStudent()
        {
            Course course = new Course("Course");
            Student testStudent = new Student("Pesho", 20000);
            testStudent = null;
            course.AddStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void removeNullStudent()
        {
            Course course = new Course("Course");
            Student testStudent = new Student("Pesho", 20000);
            course.AddStudent(testStudent);
            testStudent = null;
            course.RemoveStudent(testStudent);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeWrongStudent()
        {
            Course course = new Course("Course");
            Student testStudent = new Student("Pesho", 20000);
            Student testStudent2 = new Student("Pesho2", 20002);
            course.AddStudent(testStudent);
            course.RemoveStudent(testStudent2);
        }
    }


    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void correctStudentSigningIn()
        {
            School.School school = new School.School();
            Student testStudent = new Student("Test Student", 10000);
            school.SignInNewStudent(testStudent);
        }

        [TestMethod]
        public void correctStudentSigningOut()
        {
            School.School school = new School.School();
            Student testStudent = new Student("Test Student", 10000);
            school.SignInNewStudent(testStudent);
            school.SignOutStudent(testStudent);
        }

        [TestMethod]
        public void corectAddCourse()
        {
            Course course = new Course("Test Course");
            School.School school = new School.School();
        }

        [TestMethod]
        public void correctAddingStudentToCourse()
        {
            School.School school = new School.School();
            Course course = new Course("Test Course");
            school.CreateNewCourse(course);
            Student testStudent = new Student("Test Student", 10000);
            school.SignInNewStudent(testStudent);
            course.AddStudent(testStudent);
        }

        [TestMethod]
        public void CheckCourses()
        {
            School.School school = new School.School();
            Course course = new Course("Test Course");
            school.CreateNewCourse(course);
            Assert.AreEqual(school.Courses[0].Name, course.Name);
        }
        [TestMethod]

        public void CheckStudents()
        {
            School.School school = new School.School();
            Student testStudent = new Student("Test Student", 10000);
            school.SignInNewStudent(testStudent);
            Assert.AreEqual(school.Students[0].Name, testStudent.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addCourseTwice()
        {
            School.School school = new School.School();
            Course course = new Course("Test Course");
            school.CreateNewCourse(course);
            school.CreateNewCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void sameStudentSigningInTwice()
        {
            School.School school = new School.School();
            Student testStudent = new Student("Test Student", 10000);
            school.SignInNewStudent(testStudent);
            school.SignInNewStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeStudentWhichIsSignedForACourse()
        {
            School.School school = new School.School();
            Course course = new Course("Test Course");
            Student testStudent = new Student("Test Student", 10000);
            school.SignInNewStudent(testStudent);
            school.CreateNewCourse(course);
            course.AddStudent(testStudent);
            school.SignOutStudent(testStudent);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeNonExistingStudent()
        {
            School.School school = new School.School();
            Student testStudent = new Student("Test Student", 10000);
            school.SignOutStudent(testStudent);

        }
    }
}


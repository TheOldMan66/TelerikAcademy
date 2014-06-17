using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    // END OF UNMODIFYABLE CODE

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private List<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            topics = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Local course name cannot be empty");
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(": Name=");
            result.Append(this.Name);
            if (this.teacher != null)
            {
                result.Append("; Teacher=");
                result.Append(this.teacher.Name);
            }
            if (this.topics.Count > 0)
            {
                result.Append("; Topics=[");
                foreach (string topic in this.topics)
                {
                    result.Append(topic);
                    result.Append(", ");
                }
                result.Remove(result.Length - 2, 2);
                result.Append("]");
            }

            return result.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Lab cannot be null or empty");
                this.lab = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "; Lab=" + this.Lab;
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;
        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Town cannot be null or empty");
                this.town = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "; Town=" + this.Town;
        }
    }

    public class Teacher : ITeacher
    {
        private string name;
        private List<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Teacher name cannot be empty");
                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            courses.Add(course);
        }

        public override string ToString()
        {
            // Teacher: Name=(teacher name); Courses=[(course names – comma separated)]
            StringBuilder result = new StringBuilder();
            result.Append("Teacher: Name=");
            result.Append(this.Name);
            if (this.courses.Count > 0)
            {
                result.Append("; Courses=[");
                foreach (ICourse course in this.courses)
                {
                    result.Append(course.Name);
                    result.Append(", ");
                }
                result.Remove(result.Length - 2, 2);
                result.Append("]");
            }
            return result.ToString();
        }
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}

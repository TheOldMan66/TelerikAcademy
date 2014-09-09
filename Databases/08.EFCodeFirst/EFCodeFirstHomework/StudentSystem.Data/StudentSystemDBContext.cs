namespace StudentSystem.Data
{
    using StudentSystem.Model;
    using System.Data.Entity;

    public class StudentSystemDBContext : DbContext
    {
        public StudentSystemDBContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDBContext, Configuration>());
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}

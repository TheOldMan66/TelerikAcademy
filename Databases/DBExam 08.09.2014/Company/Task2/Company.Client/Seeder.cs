namespace Company.Client
{
    using System;
    using Company.Model;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    class Seeder
    {

        static void PopulateDepartments(CompanyEntities db)
        {
            // generate departments
            Console.WriteLine("Generating departments");
            HashSet<Departmens> uniqueDepts = new HashSet<Departmens>();
            RandomDataGenerator rnd = new RandomDataGenerator();
            while (uniqueDepts.Count < 100)
            {
                Departmens dept = new Departmens();
                dept.Name = rnd.GetString(10, 50);
                uniqueDepts.Add(dept);
            }
            foreach (var dept in uniqueDepts)
            {

                db.Departmens.Add(dept);
            }
            db.SaveChanges();
            Console.WriteLine("Departments generated");
        }
        static void PopulateProjects(CompanyEntities db)
        {
            // generate projects
            Console.WriteLine("Generating projects");
            RandomDataGenerator rnd = new RandomDataGenerator();
            for (int i = 0; i < 100; i++) // must be 1000
            {
                Projects tmpProject = new Projects();
                tmpProject.Name = rnd.GetString(5, 50);
                db.Projects.Add(tmpProject);
                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write("\rGenerating projcets - {0} generated so far", i);
                }
            }
            db.SaveChanges();
            Console.WriteLine("\nProjects generated");
        }

        static void PopulateEmployees(CompanyEntities db)
        {
            // generate employees
            RandomDataGenerator rnd = new RandomDataGenerator();
            List<int> projects = new List<int>(db.Projects.Select(p => p.ID));
            List<int> departments = new List<int>(db.Departmens.Select(p => p.ID));

            //sorry, my computer is from jurasic age...
            for (int i = 0; i < 1000; i++) // must be 5000
            {
                Employees empl = new Employees();
                empl.FirstName = rnd.GetString(5, 20);
                empl.LastName = rnd.GetString(5, 20);
                empl.Salary = rnd.GetInt(50000, 250000);
                empl.DepartmentID = departments[rnd.GetInt(0, departments.Count - 1)];
                db.Employees.Add(empl);
                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write("\rGenerating employees - {0} generated so far", i);
                }
            }
            db.SaveChanges();
            Console.WriteLine("\nEmployees generated");
        }

        static void AssociateEmployeesWithProjects(CompanyEntities db)
        {
            // generate relationships employeee - project
            List<int> empls = new List<int>(db.Employees.Select(e => e.ID));
            List<int> projs = new List<int>(db.Projects.Select(p => p.ID));
            RandomDataGenerator rnd = new RandomDataGenerator();

            for (int i = 0; i < empls.Count; i++)
            {
                HashSet<int> recentProjects = new HashSet<int>();
                int numOfProjs = rnd.GetInt(1, 5);
                for (int j = 0; j < numOfProjs; j++)
                {
                    EmployeesProjects assoc = new EmployeesProjects();
                    assoc.EmployeeID = empls[i];
                    do
                    {
                        int projectNo = projs[rnd.GetInt(0, projs.Count - 1)];
                        if (!recentProjects.Contains(projectNo))
                        {
                            assoc.ProjectID = projectNo;
                            recentProjects.Add(projectNo);
                        }
                    } while (assoc.ProjectID == 0);
                    Console.WriteLine("Empl:{0} Project: {1}", assoc.EmployeeID, assoc.ProjectID);
                    int startOffset = rnd.GetInt(-100, 0);
                    int endOffset = rnd.GetInt(0, 100);
                    assoc.StartDate = DateTime.Now.AddDays(startOffset);
                    assoc.EndDate = DateTime.Now.AddDays(endOffset);
                    db.EmployeesProjects.Add(assoc);
                }
                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write("\rGenerating associations - {0} generated so far", i);
                }
            }
            db.SaveChanges();
            Console.WriteLine("Associations generated");

        }

        static void PopulateReports(CompanyEntities db)
        {
            // generate reports
            RandomDataGenerator rnd = new RandomDataGenerator();
            List<int> empl = new List<int>(db.Employees.Select(e => e.ID));

            //sorry, my computer is from jurasic age...
            for (int i = 0; i < empl.Count; i++)
            {
                int numOfReps = rnd.GetInt(40, 60);
                for (int j = 0; j < numOfReps; j++)
                {
                    Reports report = new Reports();
                    report.EmployeeID = empl[i];
                    report.TimeOfReport = new DateTime(
                        rnd.GetInt(2000, 2014),
                        rnd.GetInt(1, 12),
                        rnd.GetInt(1, 28),
                        rnd.GetInt(0, 23),
                        rnd.GetInt(0, 59),
                        rnd.GetInt(0, 59));
                    db.Reports.Add(report);
                }
                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write("\rGenerating reports - {0} generated so far", i);
                }
            }
            db.SaveChanges();
            Console.WriteLine("\nEmployees generated");
        }

        static void Main(string[] args)
        {
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;
            List<int> deptsIDInBase = new List<int>();

            PopulateDepartments(db);
            PopulateProjects(db);
            PopulateEmployees(db);
            AssociateEmployeesWithProjects(db);
            PopulateReports(db);
            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}

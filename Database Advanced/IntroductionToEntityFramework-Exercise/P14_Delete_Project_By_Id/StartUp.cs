using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P14_Delete_Project_By_Id
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var project = dbContext.Projects.First(p => p.ProjectId == 2);

                dbContext.EmployeesProjects.ToList().ForEach(ep => dbContext.EmployeesProjects.Remove(ep));
                dbContext.Projects.Remove(project);

                dbContext.SaveChanges();

                dbContext.Projects.Take(10).Select(p => p.Name).ToList().ForEach(p => Console.WriteLine(p));
            }
        }
    }
}

using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P12_Increase_Salaries
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                context.Employees
                    .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                         .Contains(e.Department.Name))
                    .ToList()
                    .ForEach(e => e.Salary *= 1.12m);

                context.SaveChanges();

                context.Employees
                    .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                        .Contains(e.Department.Name))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                    .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})"));
            }
        }
    }
}

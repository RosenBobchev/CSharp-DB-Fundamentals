using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P05_Emp_From_Research_And_Development
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(x => x.Department.Name == "Research and Development")
                    .OrderBy(x => x.Salary)
                    .ThenByDescending(x => x.FirstName)
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.Department.Name,
                        x.Salary
                    }).ToList();

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:F2}");
                }
            }
        }
    }
}

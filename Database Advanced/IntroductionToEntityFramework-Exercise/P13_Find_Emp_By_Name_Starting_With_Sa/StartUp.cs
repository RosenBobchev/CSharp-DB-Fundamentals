using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P13_Find_Emp_By_Name_Starting_With_Sa
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                dbContext.Employees
                    .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                    .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                    .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));
            }
        }
    }
}

using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P04_Employees_With_Salary_Over_50_000
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employeesNames = context.Employees
                    .Where(x => x.Salary > 50000)
                    .OrderBy(x => x.FirstName)
                    .Select(x => x.FirstName)
                    .ToList();

                foreach (var name in employeesNames)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}

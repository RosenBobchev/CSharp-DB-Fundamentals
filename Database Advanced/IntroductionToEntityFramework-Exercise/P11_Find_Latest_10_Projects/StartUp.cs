using P02_DatabaseFirst.Data;
using System;
using System.Globalization;
using System.Linq;

namespace P11_Find_Latest_10_Projects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                context.Projects.OrderByDescending(p => p.StartDate).Take(10).Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name}{Environment.NewLine}{p.Description}{Environment.NewLine}{p.StartDate}"));
            }
        }
    }
}

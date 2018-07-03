using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace P06_Adding_A_New_Address_And_Updating_Emp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                var employee = context.Employees.Single(x => x.LastName == "Nakov").Address = address;

                context.SaveChanges();

                context.Employees.OrderByDescending(e => e.Address.AddressId).Take(10).Select(e => e.Address.AddressText).ToList().ForEach(at => Console.WriteLine(at));
            }
        }
    }
}

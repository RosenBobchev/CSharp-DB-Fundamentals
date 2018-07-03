using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P08_Addresses_By_Town
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                context.Addresses.GroupBy(a => new
                {
                    a.AddressId,
                    a.AddressText,
                    a.Town.Name
                },
                (key, group) => new
                {
                    AddrText = key.AddressText,
                    Town = key.Name,
                    Count = group.Sum(a => a.Employees.Count)
                })
                .OrderByDescending(o => o.Count)
                .ThenBy(o => o.Town)
                .ThenBy(o => o.AddrText)
                .Take(10)
                .ToList()
                .ForEach(o => Console.WriteLine($"{o.AddrText}, {o.Town} - {o.Count} employees"));
            }
        }
    }
}

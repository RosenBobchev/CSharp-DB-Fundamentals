using BookShop.Data;
using System;
using System.Linq;
using System.Text;

namespace _12.ProfitByCategory
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string result = GetTotalProfitByCategory(context);
                Console.WriteLine(result);
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfit = context.Categories.Select(x => new
            {
                x.Name,
                ProfitByCategory = x.CategoryBooks.Select(cb => cb.Book.Price * cb.Book.Copies).Sum()
            })
                                              .OrderByDescending(x => x.ProfitByCategory)
                                              .ToList();

            var sb = new StringBuilder();

            foreach (var c in totalProfit)
            {
                sb.AppendLine($"{c.Name} ${c.ProfitByCategory:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

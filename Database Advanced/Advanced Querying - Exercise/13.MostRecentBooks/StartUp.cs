using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace _13.MostRecentBooks
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string result = GetMostRecentBooks(context);

                Console.WriteLine(result);
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                                    .Include(x => x.CategoryBooks)
                                    .Select(x => new
                                    {
                                        x.Name,
                                        Books = x.CategoryBooks.Select(b => b.Book).OrderByDescending(b => b.ReleaseDate).Take(3).ToList()
                                    }).OrderBy(x => x.Name).ToList();


            var sb = new StringBuilder();

            foreach (var category in mostRecentBooks)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

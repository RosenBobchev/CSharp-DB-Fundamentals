using BookShop.Data;
using System;
using System.Linq;

namespace _01.AgeRestriction
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BookShopContext context = new BookShopContext())
            {
                string command = Console.ReadLine();
                string result = GetBooksByAgeRestriction(context, command);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var bookTitles = context.Books.Select(x => new { x.Title, x.AgeRestriction }).ToList()
                                      .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                                      .OrderBy(x => x.Title).ToList();

            return string.Join(Environment.NewLine, bookTitles.Select(x => x.Title));
        }
    }
}

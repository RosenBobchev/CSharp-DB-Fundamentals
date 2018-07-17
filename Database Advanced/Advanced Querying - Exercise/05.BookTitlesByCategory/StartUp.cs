using BookShop.Data;
using System;
using System.Linq;

namespace _05.BookTitlesByCategory
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string input = Console.ReadLine();

                string result = GetBooksByCategory(context, input);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToArray();

            var categoryBooks = context.Books.Select(x => new
            {
                x.Title,
                BookCategories = x.BookCategories.Select(b => new { b.Category.Name }).ToList()
            })
                                             .Where(x => x.BookCategories.Any(b => args.Contains(b.Name.ToLower())))
                                             .OrderBy(x => x.Title)
                                             .ToList();

            return string.Join(Environment.NewLine, categoryBooks.Select(x => x.Title));
        }
    }
}

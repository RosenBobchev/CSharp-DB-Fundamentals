using BookShop.Data;
using System;
using System.Linq;
using System.Text;

namespace _09.BookSearchByAuthor
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string input = Console.ReadLine();

                string result = GetBooksByAuthor(context, input);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context.Books.Select(x => new { x.Title, x.BookId, x.Author.LastName, FullName =                                                        x.Author.FirstName + " " + x.Author.LastName })
                                             .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
                                             .OrderBy(x => x.BookId)
                                             .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksByAuthor)
            {
                sb.AppendLine($"{book.Title} ({book.FullName})");
            }

            return sb.ToString().Trim();
        }
    }
}

using BookShop.Data;
using System;
using System.Linq;
using System.Text;

namespace _03.BooksByPrice
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string result = GetBooksByPrice(context);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksPrice = context.Books.Select(x => new { x.Title, x.Price }).ToList()
                                          .Where(x => x.Price > 40)
                                          .OrderByDescending(x => x.Price)
                                          .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}

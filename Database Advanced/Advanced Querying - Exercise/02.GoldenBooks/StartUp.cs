using BookShop.Data;
using System;
using System.Linq;

namespace _02.GoldenBooks
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string result = GetGoldenBooks(context);

                Console.WriteLine(result);
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books.Select(x => new { x.Title, x.Copies, x.BookId, x.EditionType }).ToList()
                                           .Where(x => x.Copies < 5000)
                                           .Where(x => x.EditionType == BookShop.Models.EditionType.Gold)
                                           .OrderBy(x => x.BookId).ToList();

            return string.Join(Environment.NewLine, goldenBooks.Select(x => x.Title));
        }
    }
}

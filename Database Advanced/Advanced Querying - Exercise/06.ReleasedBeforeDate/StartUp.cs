using BookShop.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _06.ReleasedBeforeDate
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string date = Console.ReadLine();

                string result = GetBooksReleasedBefore(context, date);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var convertedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var releasedBooks = context.Books.Select(x => new { x.Title, x.Price, x.EditionType, x.ReleaseDate })
                                             .Where(x => x.ReleaseDate < convertedDate)
                                             .OrderByDescending(x => x.ReleaseDate)
                                             .ToList();

            var sb = new StringBuilder();

            foreach (var book in releasedBooks)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}

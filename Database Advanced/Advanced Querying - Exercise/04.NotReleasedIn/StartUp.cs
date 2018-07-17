using BookShop.Data;
using System;
using System.Linq;

namespace _04.NotReleasedIn
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                int year = int.Parse(Console.ReadLine());

                string result = GetBooksNotReleasedIn(context, year);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var notReleased = context.Books.Select(x => new { x.Title, x.BookId, x.ReleaseDate }).ToList()
                                           .Where(x => x.ReleaseDate.Value.Year != year)
                                           .OrderBy(x => x.BookId)
                                           .ToList();

            return string.Join(Environment.NewLine, notReleased.Select(x => x.Title));
        }
    }
}

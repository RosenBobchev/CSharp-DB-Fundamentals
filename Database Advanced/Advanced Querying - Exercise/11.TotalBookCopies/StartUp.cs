using BookShop.Data;
using System;
using System.Linq;
using System.Text;

namespace _11.TotalBookCopies
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string result = CountCopiesByAuthor(context);
                Console.WriteLine(result);
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesCount = context.Authors.Select(x => new
            {
                FullName = x.FirstName + " " + x.LastName,
                Copies = x.Books.Select(b => b.Copies).Sum()
            })
                                             .OrderByDescending(x => x.Copies).ToList();

            var sb = new StringBuilder();

            foreach (var copy in copiesCount)
            {
                sb.AppendLine($"{copy.FullName} - {copy.Copies}");
            }

            return sb.ToString().Trim();
        }
    }
}

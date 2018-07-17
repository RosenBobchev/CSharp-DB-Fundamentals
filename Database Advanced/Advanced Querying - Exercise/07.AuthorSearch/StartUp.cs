using BookShop.Data;
using System;
using System.Linq;

namespace _07.AuthorSearch
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                string input = Console.ReadLine();

                string result = GetAuthorNamesEndingIn(context, input);
                Console.WriteLine(result);
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors.Select(x => new { FullName = x.FirstName + " " + x.LastName,                                                                                             x.FirstName })
                                             .Where(x => x.FirstName.EndsWith(input))
                                             .OrderBy(x => x.FullName)
                                             .ToList();

            return string.Join(Environment.NewLine, authorNames.Select(x => x.FullName));
        }
    }
}

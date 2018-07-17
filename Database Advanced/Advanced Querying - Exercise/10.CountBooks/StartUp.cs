using BookShop.Data;
using System;
using System.Linq;

namespace _10.CountBooks
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                int lengthCheck = int.Parse(Console.ReadLine());

                int result = CountBooks(context, lengthCheck);

                Console.WriteLine(result);
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books.Where(x => x.Title.Length > lengthCheck).Count();

            return booksCount;
        }
    }
}

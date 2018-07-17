using BookShop.Data;
using System;
using System.Linq;

namespace _14.IncreasePrices
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                IncreasePrices(context);
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010).ToList();
            books.ForEach(x => x.Price += 5);

            context.SaveChanges();
        }
    }
}

﻿using BookShop.Data;
using System;
using System.Linq;

namespace _15.RemoveBooks
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                int deletedBooks = RemoveBooks(context);
                Console.WriteLine($"{deletedBooks} books were deleted");
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Copies < 4200).ToList();

            int deletedBooks = books.Count;
            context.Books.RemoveRange(books);

            context.SaveChanges();

            return deletedBooks;
        }
    }
}

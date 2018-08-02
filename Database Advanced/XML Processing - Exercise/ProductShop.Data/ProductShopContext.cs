using Microsoft.EntityFrameworkCore;
using ProductShop.Models;
using System;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(e => new { e.CategoryId, e.ProductId });

            modelBuilder.Entity<Product>()
                   .HasOne(x => x.Buyer)
                   .WithMany(x => x.ProductsBought)
                   .HasForeignKey(x => x.BuyerId);

            modelBuilder.Entity<Product>()
                   .HasOne(x => x.Seller)
                   .WithMany(x => x.ProductsSold)
                   .HasForeignKey(x => x.SellerId);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.Property(x => x.Email)
                   .HasMaxLength(80)
                   .IsUnicode(false);

            builder.HasMany(x => x.Sales)
                   .WithOne(x => x.Customer)
                   .HasForeignKey(x => x.CustomerId);
        }
    }
}

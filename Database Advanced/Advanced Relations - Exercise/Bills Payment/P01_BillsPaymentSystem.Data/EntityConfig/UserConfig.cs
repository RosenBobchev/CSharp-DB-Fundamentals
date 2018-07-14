﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName)
                       .IsUnicode();

            builder.Property(e => e.LastName)
                       .IsUnicode();

            builder.Property(e => e.Email)
                       .IsUnicode(false);

            builder.Property(e => e.Password)
                       .IsUnicode(false);

            builder.HasMany(e => e.PaymentMethods)
                       .WithOne(e => e.User)
                       .HasForeignKey(e => e.UserId);
        }
    }
}

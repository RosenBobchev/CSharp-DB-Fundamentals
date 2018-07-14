using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasIndex(pm => new { pm.BankAccountId, pm.CreditCardId, pm.UserId }).IsUnique();

            builder.HasOne(pm => pm.CreditCard)
                   .WithOne(pm => pm.PaymentMethod)
                   .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId);

            builder.HasOne(pm => pm.BankAccount)
                   .WithOne(pm => pm.PaymentMethod)
                   .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId);
        }
    }
}

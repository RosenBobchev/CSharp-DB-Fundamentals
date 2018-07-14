using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public CreditCard()
        {}

        public CreditCard(DateTime expirationDate, decimal moneyOwed, decimal limit)
        {
            this.ExpirationDate = expirationDate;
            this.MoneyOwed = moneyOwed;
            this.Limit = limit;
        }

        [Key]
        public int CreditCardId { get; set; }

        [NotMapped]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public decimal Limit { get; set; }

        [Required]
        public decimal MoneyOwed { get; private set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        [Required]
        public DateTime ExpirationDate { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.MoneyOwed -= amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (this.LimitLeft - amount >= 0)
            {
                this.MoneyOwed += amount;
            }
        }
    }
}

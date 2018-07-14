﻿using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public User User { get; set; }
        public int UserId { get; set; }

        public BankAccount BankAccount { get; set; }
        public int? BankAccountId { get; set; }

        public CreditCard CreditCard { get; set; }
        public int? CreditCardId { get; set; }
    }
}
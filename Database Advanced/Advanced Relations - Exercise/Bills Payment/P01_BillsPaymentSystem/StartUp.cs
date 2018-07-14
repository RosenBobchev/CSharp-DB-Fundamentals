using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Seed(context);

                User user = GetUser(context);

                Console.Write("Do you want to pay your bills? (Yes or No) ");
                var answer = Console.ReadLine();
                while (true)
                {
                    if (answer == "Yes")
                    {
                        Console.Write("Enter bills amount: ");
                        var amount = decimal.Parse(Console.ReadLine());
                        PayBills(user, amount);
                    }
                    else if (answer == "No")
                    {
                        Console.WriteLine("Here is information about your account:");
                        PrintUser(user);
                    }
                    else if (answer != "Yes" && answer != "No")
                    {
                        Console.Write("Do you want to pay your bills? (Yes or No) ");
                        answer = Console.ReadLine();
                        continue;
                    }

                    break;
                }
            }
        }

        private static void PayBills(User user, decimal amount)
        {
            var bankAccountBalance = user.PaymentMethods.Where(x => x.BankAccount != null).Sum(x => x.BankAccount.Balance);
            var creditCardBalance = user.PaymentMethods.Where(x => x.CreditCard != null).Sum(x => x.CreditCard.LimitLeft);

            var totalBalance = bankAccountBalance + creditCardBalance;

            if (totalBalance >= amount)
            {
                var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null).Select(x => x.BankAccount).OrderBy(x => x.BankAccountId);

                foreach (var bankAccount in bankAccounts)
                {
                    if (bankAccount.Balance >= amount)
                    {
                        bankAccount.Withdraw(amount);
                        amount = 0;
                        Console.WriteLine("Congratulations you paid your bills! Now you are broke :)");
                    }
                    else
                    {
                        amount -= bankAccount.Balance;
                        bankAccount.Withdraw(bankAccount.Balance);
                        Console.WriteLine("Not enough money try again!");
                    }

                    if (amount == 0)
                    {
                        return;
                    }
                }

                var creditCards = user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).OrderBy(x => x.CreditCardId);

                foreach (var creditCard in creditCards)
                {
                    if (creditCard.LimitLeft >= amount)
                    {
                        creditCard.Withdraw(amount);
                        amount = 0;
                        Console.WriteLine("Congratulations you paid your bills! Now you are broke :)");
                    }
                    else
                    {
                        amount -= creditCard.LimitLeft;
                        creditCard.Withdraw(creditCard.LimitLeft);
                        Console.WriteLine("Not enough money try again!");
                    }

                    if (amount == 0)
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds! You are broke :)");
            }
        }

        private static void PrintUser(User user)
        {
            Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            Console.WriteLine($"BankAccounts:");

            var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null).Select(x => x.BankAccount).ToList();

            foreach (var bankAccount in bankAccounts)
            {
                Console.WriteLine($"-- ID: {bankAccount.BankAccountId}");
                Console.WriteLine($"--- Balance: {bankAccount.Balance:F2}");
                Console.WriteLine($"--- Bank: {bankAccount.BankName}");
                Console.WriteLine($"--- SWIFT: {bankAccount.SwiftCode}");
            }

            Console.WriteLine($"CreditCards:");
            var creditCards = user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).ToList();

            foreach (var creditCard in creditCards)
            {
                Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                Console.WriteLine($"--- Limit: {creditCard.Limit:F2}");
                Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwed:F2}");
                Console.WriteLine($"--- Limit Left: {creditCard.LimitLeft:F2}");
                Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate.ToString("yyyy/MM")} ");
            }
        }

        private static User GetUser(BillsPaymentSystemContext context)
        {
            int userId = int.Parse(Console.ReadLine());

            User user = null;

            while (true)
            {
                user = context.Users
                              .Where(u => u.UserId == userId)
                              .Include(u => u.PaymentMethods)
                              .ThenInclude(u => u.BankAccount)
                              .Include(u => u.PaymentMethods)
                              .ThenInclude(u => u.CreditCard)
                              .FirstOrDefault();

                if (user == null)
                {
                    userId = int.Parse(Console.ReadLine());
                    continue;
                }

                break;
            }

            return user;
        }

        private static void Seed(BillsPaymentSystemContext context)
        {
            var users = new[]
            {
                new User
                {
                    FirstName = "Pesho",
                    LastName = "Ivanov",
                    Email = "pesho@abv.bg",
                    Password = "123"
                },

                new User
                {
                    FirstName = "Gosho",
                    LastName = "Petrov",
                    Email = "gosho@gmail.com",
                    Password = "234"
                },

                new User
                {
                    FirstName = "Stamat",
                    LastName = "Todorov",
                    Email = "stamat@yahoo.com",
                    Password = "345"
                },

                new User
                {
                    FirstName = "Toshko",
                    LastName = "Vladimirov",
                    Email = "toshko@bnr.bg",
                    Password = "456"
                }
            };

            context.Users.AddRange(users);

            var creditCards = new[]
            {
                new CreditCard(new DateTime(2018, 6, 20), 1500, 15000),
                new CreditCard(new DateTime(2018, 6, 25), 1800, 20000),
                new CreditCard(new DateTime(2019, 7, 4), 14000, 15000),
                new CreditCard(new DateTime(2019, 2, 5), 4500, 16000)
            };

            context.CreditCards.AddRange(creditCards);

            var bankAccounts = new[]
            {
                new BankAccount("SG Expresbank", "TGBHJKL", 2455),
                new BankAccount("Investbank", "TBGINKFL", 12000),
                new BankAccount("DSK", "TBGDSK", 14000),
                new BankAccount("Raiffensen bank", "TBGFRF", 8500)
            };

            context.BankAccounts.AddRange(bankAccounts);

            var paymentMethods = new[]
            {
                new PaymentMethod
                {
                    User = users[0],
                    Type = Data.Models.Type.BankAccount,
                    BankAccount = bankAccounts[0]
                },

                new PaymentMethod
                {
                    User = users[0],
                    Type = Data.Models.Type.BankAccount,
                    BankAccount = bankAccounts[1]
                },

                new PaymentMethod
                {
                    User = users[0],
                    Type = Data.Models.Type.CreditCard,
                    CreditCard = creditCards[0]
                },

                new PaymentMethod
                {
                    User = users[1],
                    Type = Data.Models.Type.CreditCard,
                    CreditCard = creditCards[1]
                },

                new PaymentMethod
                {
                    User = users[2],
                    Type = Data.Models.Type.BankAccount,
                    BankAccount = bankAccounts[2]
                },

                new PaymentMethod
                {
                    User = users[2],
                    Type = Data.Models.Type.CreditCard,
                    CreditCard = creditCards[2]
                },

                new PaymentMethod
                {
                    User = users[2],
                    Type = Data.Models.Type.CreditCard,
                    CreditCard = creditCards[3]
                },

                new PaymentMethod
                {
                    User = users[3],
                    Type = Data.Models.Type.BankAccount,
                    BankAccount = bankAccounts[3]
                }
            };

            context.PaymentMethods.AddRange(paymentMethods);

            context.SaveChanges();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DAL.Contexts;
using AccountingApp.DB.Configurations;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using Microsoft.EntityFrameworkCore;

namespace AccountingApp.DB.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Account> Account { get; set; } = null!;
        public DbSet<Transaction> Transaction { get; set; } = null!;
        public DbSet<Detail> Detail { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<TransactionType> TransactionType { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new DetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "user1@example.com", Password = "password1", IsActive = true },
                new User { Id = 2, Email = "user2@example.com", Password = "password2", IsActive = true },
                new User { Id = 3, Email = "user3@example.com", Password = "password3", IsActive = false },
                new User { Id = 4, Email = "user4@example.com", Password = "password4", IsActive = true },
                new User { Id = 5, Email = "user5@example.com", Password = "password5", IsActive = false },
                new User { Id = 6, Email = "user6@example.com", Password = "password6", IsActive = true },
                new User { Id = 7, Email = "user7@example.com", Password = "password7", IsActive = true },
                new User { Id = 8, Email = "user8@example.com", Password = "password8", IsActive = true },
                new User { Id = 9, Email = "user9@example.com", Password = "password9", IsActive = false }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Name = "Savings Account", Balance = 1500.50m, UserId = 1 },
                new Account { Id = 2, Name = "Checking Account", Balance = 250.00m, UserId = 1 },
                new Account { Id = 3, Name = "Investment Account", Balance = 5000.00m, UserId = 2 },
                new Account { Id = 4, Name = "Emergency Fund", Balance = 1000.00m, UserId = 3 },
                new Account { Id = 5, Name = "Travel Fund", Balance = 300.00m, UserId = 3 },
                new Account { Id = 6, Name = "Education Fund", Balance = 2000.00m, UserId = 4 },
                new Account { Id = 7, Name = "Holiday Fund", Balance = 400.00m, UserId = 5 },
                new Account { Id = 8, Name = "Retirement Fund", Balance = 10000.00m, UserId = 6 },
                new Account { Id = 9, Name = "Health Savings", Balance = 1200.00m, UserId = 7 }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, Name = "Groceries", AccountId = 1, Repetition = RepetitionEnum.None, SetDate = new DateTime(2024, 1, 1), EndDate = null },
                new Transaction { Id = 2, Name = "Electricity Bill", AccountId = 2, Repetition = RepetitionEnum.Monthly, SetDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31) },
                new Transaction { Id = 3, Name = "Salary", AccountId = 3, Repetition = RepetitionEnum.Monthly, SetDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31) },
                new Transaction { Id = 4, Name = "Car Loan", AccountId = 4, Repetition = RepetitionEnum.Weekly, SetDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31) },
                new Transaction { Id = 5, Name = "Internet Subscription", AccountId = 5, Repetition = RepetitionEnum.Monthly, SetDate = new DateTime(2024, 1, 15), EndDate = new DateTime(2024, 12, 15) },
                new Transaction { Id = 6, Name = "Gym Membership", AccountId = 6, Repetition = RepetitionEnum.Yearly, SetDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2025, 1, 1) },
                new Transaction { Id = 7, Name = "Netflix Subscription", AccountId = 7, Repetition = RepetitionEnum.Monthly, SetDate = new DateTime(2024, 1, 20), EndDate = new DateTime(2024, 12, 20) },
                new Transaction { Id = 8, Name = "Donation", AccountId = 8, Repetition = RepetitionEnum.None, SetDate = new DateTime(2024, 2, 1), EndDate = null },
                new Transaction { Id = 9, Name = "House Rent", AccountId = 9, Repetition = RepetitionEnum.Monthly, SetDate = new DateTime(2024, 1, 5), EndDate = new DateTime(2024, 12, 5) }
            );
            
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Groceries", TransactionDetailId = 1 },
                new Category { Id = 2, Name = "Utilities", TransactionDetailId = 2 },
                new Category { Id = 3, Name = "Rent", TransactionDetailId = 3 },
                new Category { Id = 4, Name = "Entertainment", TransactionDetailId = 4 },
                new Category { Id = 5, Name = "Transportation", TransactionDetailId = 5 },
                new Category { Id = 6, Name = "Healthcare", TransactionDetailId = 6 },
                new Category { Id = 7, Name = "Education", TransactionDetailId = 7 },
                new Category { Id = 8, Name = "Savings", TransactionDetailId = 8 },
                new Category { Id = 9, Name = "Travel", TransactionDetailId = 9 }
            );

            modelBuilder.Entity<Detail>().HasData(
                new Detail { Id = 1, Amount = -150.00m, TransactionDate = new DateTime(2024, 11, 10, 17, 27, 0), Note = "Grocery shopping", TransactionId = 1, CategoryId = 1, TransactionTypeId = 1 },
                new Detail { Id = 2, Amount = -75.50m, TransactionDate = new DateTime(2024, 2, 19, 8, 8, 0), Note = "Electricity bill payment", TransactionId = 2, CategoryId = 2, TransactionTypeId = 2 },
                new Detail { Id = 3, Amount = 2000.00m, TransactionDate = new DateTime(2024, 3, 9, 0, 40, 0), Note = "January salary", TransactionId = 3, CategoryId = 3, TransactionTypeId = 3 },
                new Detail { Id = 4, Amount = -300.00m, TransactionDate = new DateTime(2024, 7, 10, 14, 12, 0), Note = "Car loan payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 5, Amount = -50.00m, TransactionDate = new DateTime(2024, 7, 26, 12, 17, 0), Note = "Internet subscription", TransactionId = 5, CategoryId = 5, TransactionTypeId = 2 },
                new Detail { Id = 6, Amount = -1200.00m, TransactionDate = new DateTime(2024, 1, 27, 18, 53, 0), Note = "Gym membership annual fee", TransactionId = 6, CategoryId = 6, TransactionTypeId = 2 },
                new Detail { Id = 7, Amount = -15.99m, TransactionDate = new DateTime(2024, 11, 9, 9, 22, 0), Note = "Netflix subscription fee", TransactionId = 7, CategoryId = 7, TransactionTypeId = 2 },
                new Detail { Id = 8, Amount = -100.00m, TransactionDate = new DateTime(2024, 10, 22, 1, 46, 0), Note = "Charity donation", TransactionId = 8, CategoryId = 8, TransactionTypeId = 9 },
                new Detail { Id = 9, Amount = -800.00m, TransactionDate = new DateTime(2024, 10, 24, 16, 14, 0), Note = "January house rent", TransactionId = 9, CategoryId = 9, TransactionTypeId = 2 }
            );
            
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { Id = 1, Name = "One-Time Payment" },
                new TransactionType { Id = 2, Name = "Monthly Payment" },
                new TransactionType { Id = 3, Name = "Savings for payment" },
                new TransactionType { Id = 4, Name = "Travel" },
                new TransactionType { Id = 5, Name = "Wedding" },
                new TransactionType { Id = 6, Name = "Education" },
                new TransactionType { Id = 7, Name = "Kids" },
                new TransactionType { Id = 8, Name = "Gifts" },
                new TransactionType { Id = 9, Name = "Entertainment" }
            );
        }
    }
}

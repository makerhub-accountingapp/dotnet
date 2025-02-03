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
                new Detail { Id = 9, Amount = -800.00m, TransactionDate = new DateTime(2024, 10, 24, 16, 14, 0), Note = "January house rent", TransactionId = 9, CategoryId = 9, TransactionTypeId = 2 },
                new Detail { Id = 10, Amount = -250.00m, TransactionDate = new DateTime(2024, 2, 10, 14, 30, 0), Note = "Supermarket shopping", TransactionId = 1, CategoryId = 1, TransactionTypeId = 2 },
                new Detail { Id = 11, Amount = -120.00m, TransactionDate = new DateTime(2024, 2, 15, 10, 0, 0), Note = "Electricity bill payment", TransactionId = 2, CategoryId = 2, TransactionTypeId = 2 },
                new Detail { Id = 12, Amount = 2500.00m, TransactionDate = new DateTime(2024, 2, 20, 9, 15, 0), Note = "February salary", TransactionId = 3, CategoryId = 3, TransactionTypeId = 3 },
                new Detail { Id = 13, Amount = -400.00m, TransactionDate = new DateTime(2024, 3, 5, 15, 0, 0), Note = "Car loan payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 14, Amount = -60.00m, TransactionDate = new DateTime(2024, 3, 10, 12, 0, 0), Note = "Internet subscription", TransactionId = 5, CategoryId = 5, TransactionTypeId = 2 },
                new Detail { Id = 15, Amount = -1300.00m, TransactionDate = new DateTime(2024, 2, 1, 10, 0, 0), Note = "Gym membership annual fee", TransactionId = 6, CategoryId = 6, TransactionTypeId = 2 },
                new Detail { Id = 16, Amount = -20.00m, TransactionDate = new DateTime(2024, 3, 1, 8, 30, 0), Note = "Netflix subscription fee", TransactionId = 7, CategoryId = 7, TransactionTypeId = 2 },
                new Detail { Id = 17, Amount = -150.00m, TransactionDate = new DateTime(2024, 3, 15, 17, 0, 0), Note = "Charity donation", TransactionId = 8, CategoryId = 8, TransactionTypeId = 9 },
                new Detail { Id = 18, Amount = -850.00m, TransactionDate = new DateTime(2024, 3, 10, 16, 0, 0), Note = "February house rent", TransactionId = 9, CategoryId = 9, TransactionTypeId = 2 },
                new Detail { Id = 19, Amount = -500.00m, TransactionDate = new DateTime(2024, 3, 20, 18, 30, 0), Note = "Car insurance payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 20, Amount = -300.00m, TransactionDate = new DateTime(2024, 3, 25, 11, 0, 0), Note = "Supermarket shopping", TransactionId = 1, CategoryId = 1, TransactionTypeId = 2 },
                new Detail { Id = 21, Amount = -200.00m, TransactionDate = new DateTime(2024, 4, 1, 10, 30, 0), Note = "Electricity bill payment", TransactionId = 2, CategoryId = 2, TransactionTypeId = 2 },
                new Detail { Id = 22, Amount = 2200.00m, TransactionDate = new DateTime(2024, 4, 5, 9, 15, 0), Note = "March salary", TransactionId = 3, CategoryId = 3, TransactionTypeId = 3 },
                new Detail { Id = 23, Amount = -350.00m, TransactionDate = new DateTime(2024, 4, 10, 15, 30, 0), Note = "Car loan payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 24, Amount = -70.00m, TransactionDate = new DateTime(2024, 4, 15, 12, 45, 0), Note = "Internet subscription", TransactionId = 5, CategoryId = 5, TransactionTypeId = 2 },
                new Detail { Id = 25, Amount = -1400.00m, TransactionDate = new DateTime(2024, 3, 1, 12, 0, 0), Note = "Gym membership annual fee", TransactionId = 6, CategoryId = 6, TransactionTypeId = 2 },
                new Detail { Id = 26, Amount = -25.00m, TransactionDate = new DateTime(2024, 4, 1, 9, 30, 0), Note = "Netflix subscription fee", TransactionId = 7, CategoryId = 7, TransactionTypeId = 2 },
                new Detail { Id = 27, Amount = -120.00m, TransactionDate = new DateTime(2024, 4, 10, 17, 0, 0), Note = "Charity donation", TransactionId = 8, CategoryId = 8, TransactionTypeId = 9 },
                new Detail { Id = 28, Amount = -900.00m, TransactionDate = new DateTime(2024, 4, 1, 16, 30, 0), Note = "February house rent", TransactionId = 9, CategoryId = 9, TransactionTypeId = 2 },
                new Detail { Id = 29, Amount = -400.00m, TransactionDate = new DateTime(2024, 4, 15, 18, 0, 0), Note = "Car insurance payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 30, Amount = -250.00m, TransactionDate = new DateTime(2024, 3, 20, 10, 0, 0), Note = "Restaurant dining", TransactionId = 1, CategoryId = 1, TransactionTypeId = 2 },
                new Detail { Id = 31, Amount = -180.00m, TransactionDate = new DateTime(2024, 3, 22, 14, 30, 0), Note = "Electricity bill payment", TransactionId = 2, CategoryId = 2, TransactionTypeId = 2 },
                new Detail { Id = 32, Amount = 2500.00m, TransactionDate = new DateTime(2024, 4, 1, 10, 0, 0), Note = "April salary", TransactionId = 3, CategoryId = 3, TransactionTypeId = 3 },
                new Detail { Id = 33, Amount = -350.00m, TransactionDate = new DateTime(2024, 4, 5, 13, 0, 0), Note = "Car loan payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 34, Amount = -60.00m, TransactionDate = new DateTime(2024, 4, 7, 16, 0, 0), Note = "Internet subscription", TransactionId = 5, CategoryId = 5, TransactionTypeId = 2 },
                new Detail { Id = 35, Amount = -1300.00m, TransactionDate = new DateTime(2024, 4, 1, 9, 0, 0), Note = "Gym membership annual fee", TransactionId = 6, CategoryId = 6, TransactionTypeId = 2 },
                new Detail { Id = 36, Amount = -30.00m, TransactionDate = new DateTime(2024, 4, 8, 18, 0, 0), Note = "Netflix subscription fee", TransactionId = 7, CategoryId = 7, TransactionTypeId = 2 },
                new Detail { Id = 37, Amount = -110.00m, TransactionDate = new DateTime(2024, 4, 10, 17, 30, 0), Note = "Charity donation", TransactionId = 8, CategoryId = 8, TransactionTypeId = 9 },
                new Detail { Id = 38, Amount = -950.00m, TransactionDate = new DateTime(2024, 4, 12, 14, 0, 0), Note = "March house rent", TransactionId = 9, CategoryId = 9, TransactionTypeId = 2 },
                new Detail { Id = 39, Amount = -500.00m, TransactionDate = new DateTime(2024, 4, 18, 19, 0, 0), Note = "Car insurance payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 40, Amount = -200.00m, TransactionDate = new DateTime(2024, 4, 25, 15, 0, 0), Note = "Grocery shopping", TransactionId = 1, CategoryId = 1, TransactionTypeId = 2 },
                new Detail { Id = 41, Amount = -90.00m, TransactionDate = new DateTime(2024, 4, 28, 12, 30, 0), Note = "Electricity bill payment", TransactionId = 2, CategoryId = 2, TransactionTypeId = 2 },
                new Detail { Id = 42, Amount = 2200.00m, TransactionDate = new DateTime(2024, 5, 1, 10, 0, 0), Note = "May salary", TransactionId = 3, CategoryId = 3, TransactionTypeId = 3 },
                new Detail { Id = 43, Amount = -400.00m, TransactionDate = new DateTime(2024, 5, 5, 14, 0, 0), Note = "Car loan payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 44, Amount = -65.00m, TransactionDate = new DateTime(2024, 5, 7, 16, 0, 0), Note = "Internet subscription", TransactionId = 5, CategoryId = 5, TransactionTypeId = 2 },
                new Detail { Id = 45, Amount = -1400.00m, TransactionDate = new DateTime(2024, 5, 1, 9, 0, 0), Note = "Gym membership annual fee", TransactionId = 6, CategoryId = 6, TransactionTypeId = 2 },
                new Detail { Id = 46, Amount = -35.00m, TransactionDate = new DateTime(2024, 5, 8, 18, 0, 0), Note = "Netflix subscription fee", TransactionId = 7, CategoryId = 7, TransactionTypeId = 2 },
                new Detail { Id = 47, Amount = -120.00m, TransactionDate = new DateTime(2024, 5, 10, 17, 30, 0), Note = "Charity donation", TransactionId = 8, CategoryId = 8, TransactionTypeId = 9 },
                new Detail { Id = 48, Amount = -1000.00m, TransactionDate = new DateTime(2024, 5, 12, 14, 0, 0), Note = "April house rent", TransactionId = 9, CategoryId = 9, TransactionTypeId = 2 },
                new Detail { Id = 49, Amount = -450.00m, TransactionDate = new DateTime(2024, 5, 18, 19, 0, 0), Note = "Car insurance payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 50, Amount = -120.00m, TransactionDate = new DateTime(2025, 2, 3, 14, 30, 0), Note = "Grocery shopping", TransactionId = 1, CategoryId = 1, TransactionTypeId = 2 },
                new Detail { Id = 51, Amount = -50.00m, TransactionDate = new DateTime(2025, 2, 5, 8, 0, 0), Note = "Electricity bill payment", TransactionId = 2, CategoryId = 2, TransactionTypeId = 2 },
                new Detail { Id = 52, Amount = 2100.00m, TransactionDate = new DateTime(2025, 2, 10, 9, 0, 0), Note = "February salary", TransactionId = 3, CategoryId = 3, TransactionTypeId = 3 },
                new Detail { Id = 53, Amount = -300.00m, TransactionDate = new DateTime(2025, 2, 7, 12, 15, 0), Note = "Car loan payment", TransactionId = 4, CategoryId = 4, TransactionTypeId = 2 },
                new Detail { Id = 54, Amount = -100.00m, TransactionDate = new DateTime(2025, 2, 9, 16, 30, 0), Note = "Internet subscription", TransactionId = 5, CategoryId = 5, TransactionTypeId = 2 },
                new Detail { Id = 55, Amount = -1200.00m, TransactionDate = new DateTime(2025, 2, 12, 11, 0, 0), Note = "Gym membership annual fee", TransactionId = 6, CategoryId = 6, TransactionTypeId = 2 },
                new Detail { Id = 56, Amount = -20.00m, TransactionDate = new DateTime(2025, 2, 15, 10, 30, 0), Note = "Netflix subscription fee", TransactionId = 7, CategoryId = 7, TransactionTypeId = 2 },
                new Detail { Id = 57, Amount = -130.00m, TransactionDate = new DateTime(2025, 2, 18, 14, 0, 0), Note = "Charity donation", TransactionId = 8, CategoryId = 8, TransactionTypeId = 9 },
                new Detail { Id = 58, Amount = -800.00m, TransactionDate = new DateTime(2025, 2, 21, 13, 45, 0), Note = "House rent for February", TransactionId = 9, CategoryId = 9, TransactionTypeId = 2 },
                new Detail { Id = 59, Amount = -50.00m, TransactionDate = new DateTime(2025, 2, 25, 18, 30, 0), Note = "Supermarket shopping", TransactionId = 1, CategoryId = 1, TransactionTypeId = 2 }
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

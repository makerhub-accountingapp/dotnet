using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingApp.DB.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Repetition = table.Column<int>(type: "integer", nullable: false),
                    SetDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    TransactionId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detail_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Groceries" },
                    { 2, "Utilities" },
                    { 3, "Rent" },
                    { 4, "Entertainment" },
                    { 5, "Transportation" },
                    { 6, "Healthcare" },
                    { 7, "Education" },
                    { 8, "Savings" },
                    { 9, "Travel" }
                });

            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "One-Time Payment" },
                    { 2, "Monthly Payment" },
                    { 3, "Savings for payment" },
                    { 4, "Travel" },
                    { 5, "Wedding" },
                    { 6, "Education" },
                    { 7, "Kids" },
                    { 8, "Gifts" },
                    { 9, "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "Password" },
                values: new object[,]
                {
                    { 1, "user1@example.com", true, "password1" },
                    { 2, "user2@example.com", true, "password2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 3, "user3@example.com", "password3" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "Password" },
                values: new object[] { 4, "user4@example.com", true, "password4" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 5, "user5@example.com", "password5" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "Password" },
                values: new object[,]
                {
                    { 6, "user6@example.com", true, "password6" },
                    { 7, "user7@example.com", true, "password7" },
                    { 8, "user8@example.com", true, "password8" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 9, "user9@example.com", "password9" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Balance", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 1500.50m, "Savings Account", 1 },
                    { 2, 250.00m, "Checking Account", 1 },
                    { 3, 5000.00m, "Investment Account", 2 },
                    { 4, 1000.00m, "Emergency Fund", 3 },
                    { 5, 300.00m, "Travel Fund", 3 },
                    { 6, 2000.00m, "Education Fund", 4 },
                    { 7, 400.00m, "Holiday Fund", 5 },
                    { 8, 10000.00m, "Retirement Fund", 6 },
                    { 9, 1200.00m, "Health Savings", 7 }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountId", "EndDate", "Name", "Repetition", "SetDate" },
                values: new object[,]
                {
                    { 1, 1, null, "Groceries", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electricity Bill", 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salary", 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car Loan", 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internet Subscription", 4, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gym Membership", 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netflix Subscription", 4, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, null, "Donation", 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "House Rent", 4, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Detail",
                columns: new[] { "Id", "Amount", "CategoryId", "Note", "TransactionDate", "TransactionId", "TransactionTypeId" },
                values: new object[,]
                {
                    { 1, -150.00m, 1, "Grocery shopping", new DateTime(2024, 11, 10, 17, 27, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, -75.50m, 2, "Electricity bill payment", new DateTime(2024, 2, 19, 8, 8, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 2000.00m, 3, "January salary", new DateTime(2024, 3, 9, 0, 40, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, -300.00m, 4, "Car loan payment", new DateTime(2024, 7, 10, 14, 12, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 5, -50.00m, 5, "Internet subscription", new DateTime(2024, 7, 26, 12, 17, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 6, -1200.00m, 6, "Gym membership annual fee", new DateTime(2024, 1, 27, 18, 53, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 7, -15.99m, 7, "Netflix subscription fee", new DateTime(2024, 11, 9, 9, 22, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 8, -100.00m, 8, "Charity donation", new DateTime(2024, 10, 22, 1, 46, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 9, -800.00m, 9, "January house rent", new DateTime(2024, 10, 24, 16, 14, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 10, -250.00m, 1, "Supermarket shopping", new DateTime(2024, 2, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 11, -120.00m, 2, "Electricity bill payment", new DateTime(2024, 2, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 12, 2500.00m, 3, "February salary", new DateTime(2024, 2, 20, 9, 15, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 13, -400.00m, 4, "Car loan payment", new DateTime(2024, 3, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 14, -60.00m, 5, "Internet subscription", new DateTime(2024, 3, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 15, -1300.00m, 6, "Gym membership annual fee", new DateTime(2024, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 16, -20.00m, 7, "Netflix subscription fee", new DateTime(2024, 3, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 17, -150.00m, 8, "Charity donation", new DateTime(2024, 3, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 18, -850.00m, 9, "February house rent", new DateTime(2024, 3, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 19, -500.00m, 4, "Car insurance payment", new DateTime(2024, 3, 20, 18, 30, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 20, -300.00m, 1, "Supermarket shopping", new DateTime(2024, 3, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 21, -200.00m, 2, "Electricity bill payment", new DateTime(2024, 4, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 22, 2200.00m, 3, "March salary", new DateTime(2024, 4, 5, 9, 15, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 23, -350.00m, 4, "Car loan payment", new DateTime(2024, 4, 10, 15, 30, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 24, -70.00m, 5, "Internet subscription", new DateTime(2024, 4, 15, 12, 45, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 25, -1400.00m, 6, "Gym membership annual fee", new DateTime(2024, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 26, -25.00m, 7, "Netflix subscription fee", new DateTime(2024, 4, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 27, -120.00m, 8, "Charity donation", new DateTime(2024, 4, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 28, -900.00m, 9, "February house rent", new DateTime(2024, 4, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 29, -400.00m, 4, "Car insurance payment", new DateTime(2024, 4, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 30, -250.00m, 1, "Restaurant dining", new DateTime(2024, 3, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 31, -180.00m, 2, "Electricity bill payment", new DateTime(2024, 3, 22, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 32, 2500.00m, 3, "April salary", new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 33, -350.00m, 4, "Car loan payment", new DateTime(2024, 4, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 34, -60.00m, 5, "Internet subscription", new DateTime(2024, 4, 7, 16, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 35, -1300.00m, 6, "Gym membership annual fee", new DateTime(2024, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 36, -30.00m, 7, "Netflix subscription fee", new DateTime(2024, 4, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 37, -110.00m, 8, "Charity donation", new DateTime(2024, 4, 10, 17, 30, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 38, -950.00m, 9, "March house rent", new DateTime(2024, 4, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 39, -500.00m, 4, "Car insurance payment", new DateTime(2024, 4, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 40, -200.00m, 1, "Grocery shopping", new DateTime(2024, 4, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 41, -90.00m, 2, "Electricity bill payment", new DateTime(2024, 4, 28, 12, 30, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 42, 2200.00m, 3, "May salary", new DateTime(2024, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 43, -400.00m, 4, "Car loan payment", new DateTime(2024, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 44, -65.00m, 5, "Internet subscription", new DateTime(2024, 5, 7, 16, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 45, -1400.00m, 6, "Gym membership annual fee", new DateTime(2024, 5, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 46, -35.00m, 7, "Netflix subscription fee", new DateTime(2024, 5, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 47, -120.00m, 8, "Charity donation", new DateTime(2024, 5, 10, 17, 30, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 48, -1000.00m, 9, "April house rent", new DateTime(2024, 5, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 49, -450.00m, 4, "Car insurance payment", new DateTime(2024, 5, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 50, -120.00m, 1, "Grocery shopping", new DateTime(2025, 2, 3, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 51, -50.00m, 2, "Electricity bill payment", new DateTime(2025, 2, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 52, 2100.00m, 3, "February salary", new DateTime(2025, 2, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 53, -300.00m, 4, "Car loan payment", new DateTime(2025, 2, 7, 12, 15, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 54, -100.00m, 5, "Internet subscription", new DateTime(2025, 2, 9, 16, 30, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 55, -1200.00m, 6, "Gym membership annual fee", new DateTime(2025, 2, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 56, -20.00m, 7, "Netflix subscription fee", new DateTime(2025, 2, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 57, -130.00m, 8, "Charity donation", new DateTime(2025, 2, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 58, -800.00m, 9, "House rent for February", new DateTime(2025, 2, 21, 13, 45, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 59, -50.00m, 1, "Supermarket shopping", new DateTime(2025, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_CategoryId",
                table: "Detail",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_TransactionId",
                table: "Detail",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_TransactionTypeId",
                table: "Detail",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

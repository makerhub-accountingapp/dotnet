using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingApp.DB.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Detail",
                columns: new[] { "Id", "Amount", "CategoryId", "Note", "TransactionDate", "TransactionId", "TransactionTypeId" },
                values: new object[,]
                {
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
                    { 49, -450.00m, 4, "Car insurance payment", new DateTime(2024, 5, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 49);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingApp.DB.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Detail",
                columns: new[] { "Id", "Amount", "CategoryId", "Note", "TransactionDate", "TransactionId", "TransactionTypeId" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 59);
        }
    }
}

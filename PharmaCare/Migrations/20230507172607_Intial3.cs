using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "DateCreated", "DrugName", "ExpiryDate", "ImageUrl", "price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 22, 56, 7, 481, DateTimeKind.Local).AddTicks(2735), "Acetaminophen", new DateTime(2084, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 421f },
                    { 2, new DateTime(2023, 5, 7, 22, 56, 7, 481, DateTimeKind.Local).AddTicks(2751), "Doxycycline", new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 321f },
                    { 3, new DateTime(2023, 5, 7, 22, 56, 7, 481, DateTimeKind.Local).AddTicks(2753), "Lexapro", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 401f },
                    { 4, new DateTime(2023, 5, 7, 22, 56, 7, 481, DateTimeKind.Local).AddTicks(2754), "Pantoprazole", new DateTime(2031, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 921f },
                    { 5, new DateTime(2023, 5, 7, 22, 56, 7, 481, DateTimeKind.Local).AddTicks(2756), "secukinumab", new DateTime(2027, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1123f },
                    { 6, new DateTime(2023, 5, 7, 22, 56, 7, 481, DateTimeKind.Local).AddTicks(2757), "Wegovy", new DateTime(2052, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 891f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

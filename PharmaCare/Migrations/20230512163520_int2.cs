using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class int2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SuppilerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppilerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SuppilerId);
                });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 12, 22, 5, 20, 418, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 12, 22, 5, 20, 418, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 12, 22, 5, 20, 418, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 12, 22, 5, 20, 418, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 5, 12, 22, 5, 20, 418, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 5, 12, 22, 5, 20, 418, DateTimeKind.Local).AddTicks(8693));

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SuppilerId", "DrugId", "Email", "SuppilerName" },
                values: new object[,]
                {
                    { 1, 1, "DavidWA@gmail.com ", "David Waxon" },
                    { 2, 1, "Andk@gmail.com ", "Antony " },
                    { 3, 1, "JohnSc@gmail.com ", "Johan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 11, 22, 1, 9, 496, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 11, 22, 1, 9, 496, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 11, 22, 1, 9, 496, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 11, 22, 1, 9, 496, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 5, 11, 22, 1, 9, 496, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 5, 11, 22, 1, 9, 496, DateTimeKind.Local).AddTicks(5862));
        }
    }
}

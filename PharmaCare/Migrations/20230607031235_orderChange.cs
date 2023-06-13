using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class orderChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 7, 8, 42, 34, 532, DateTimeKind.Local).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 7, 8, 42, 34, 532, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 7, 8, 42, 34, 532, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 7, 8, 42, 34, 532, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 7, 8, 42, 34, 532, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 7, 8, 42, 34, 532, DateTimeKind.Local).AddTicks(6301));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 6, 20, 47, 32, 219, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 6, 20, 47, 32, 219, DateTimeKind.Local).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 6, 20, 47, 32, 219, DateTimeKind.Local).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 6, 20, 47, 32, 219, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 6, 20, 47, 32, 219, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 6, 20, 47, 32, 219, DateTimeKind.Local).AddTicks(5671));
        }
    }
}

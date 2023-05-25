using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class chnDrug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Drugs");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5225));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2023, 5, 20, 18, 24, 15, 541, DateTimeKind.Local).AddTicks(8969), "" });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2023, 5, 20, 18, 24, 15, 541, DateTimeKind.Local).AddTicks(8985), "" });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2023, 5, 20, 18, 24, 15, 541, DateTimeKind.Local).AddTicks(8987), "" });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2023, 5, 20, 18, 24, 15, 541, DateTimeKind.Local).AddTicks(8989), "" });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2023, 5, 20, 18, 24, 15, 541, DateTimeKind.Local).AddTicks(8991), "" });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2023, 5, 20, 18, 24, 15, 541, DateTimeKind.Local).AddTicks(8993), "" });
        }
    }
}

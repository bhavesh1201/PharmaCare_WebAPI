using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class orderModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 2, 9, 40, 25, 244, DateTimeKind.Local).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 2, 9, 40, 25, 244, DateTimeKind.Local).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 2, 9, 40, 25, 244, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 2, 9, 40, 25, 244, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 2, 9, 40, 25, 244, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 2, 9, 40, 25, 244, DateTimeKind.Local).AddTicks(8768));
        }
    }
}

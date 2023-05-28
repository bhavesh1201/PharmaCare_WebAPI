using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class nEWupdss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Suppliers_DrugId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_DrugId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "DrugId",
                table: "Drugs");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 31, 23, 585, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 31, 23, 585, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 31, 23, 585, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 31, 23, 585, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 31, 23, 585, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 31, 23, 585, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_DrugId",
                table: "Suppliers",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Drugs_DrugId",
                table: "Suppliers",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Drugs_DrugId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_DrugId",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "DrugId",
                table: "Drugs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DrugId" },
                values: new object[] { new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2050), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DrugId" },
                values: new object[] { new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2078), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DrugId" },
                values: new object[] { new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2085), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DrugId" },
                values: new object[] { new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2090), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DrugId" },
                values: new object[] { new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2096), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DrugId" },
                values: new object[] { new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2101), null });

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_DrugId",
                table: "Drugs",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Suppliers_DrugId",
                table: "Drugs",
                column: "DrugId",
                principalTable: "Suppliers",
                principalColumn: "SuppilerId");
        }
    }
}

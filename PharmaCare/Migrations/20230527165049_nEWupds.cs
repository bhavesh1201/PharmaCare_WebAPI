using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class nEWupds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Suppliers_SupplierSuppilerId",
                table: "Drugs");

            migrationBuilder.RenameColumn(
                name: "SupplierSuppilerId",
                table: "Drugs",
                newName: "DrugId");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_SupplierSuppilerId",
                table: "Drugs",
                newName: "IX_Drugs_DrugId");

            migrationBuilder.AddColumn<int>(
                name: "quntity",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 22, 20, 49, 237, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SuppilerId",
                keyValue: 1,
                column: "quntity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SuppilerId",
                keyValue: 2,
                column: "quntity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SuppilerId",
                keyValue: 3,
                column: "quntity",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Suppliers_DrugId",
                table: "Drugs",
                column: "DrugId",
                principalTable: "Suppliers",
                principalColumn: "SuppilerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Suppliers_DrugId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "quntity",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "DrugId",
                table: "Drugs",
                newName: "SupplierSuppilerId");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_DrugId",
                table: "Drugs",
                newName: "IX_Drugs_SupplierSuppilerId");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Suppliers_SupplierSuppilerId",
                table: "Drugs",
                column: "SupplierSuppilerId",
                principalTable: "Suppliers",
                principalColumn: "SuppilerId");
        }
    }
}

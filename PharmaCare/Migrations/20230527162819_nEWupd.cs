using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class nEWupd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DrugId",
                table: "Suppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SupplierSuppilerId",
                table: "Drugs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "SupplierSuppilerId" },
                values: new object[] { new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(452), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "SupplierSuppilerId" },
                values: new object[] { new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(482), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "SupplierSuppilerId" },
                values: new object[] { new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(487), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "SupplierSuppilerId" },
                values: new object[] { new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(490), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "SupplierSuppilerId" },
                values: new object[] { new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(494), null });

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "SupplierSuppilerId" },
                values: new object[] { new DateTime(2023, 5, 27, 21, 58, 18, 669, DateTimeKind.Local).AddTicks(498), null });

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_SupplierSuppilerId",
                table: "Drugs",
                column: "SupplierSuppilerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Suppliers_SupplierSuppilerId",
                table: "Drugs",
                column: "SupplierSuppilerId",
                principalTable: "Suppliers",
                principalColumn: "SuppilerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Suppliers_SupplierSuppilerId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_SupplierSuppilerId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "SupplierSuppilerId",
                table: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "DrugId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 26, 21, 48, 16, 410, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 26, 21, 48, 16, 410, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 26, 21, 48, 16, 410, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 5, 26, 21, 48, 16, 410, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 5, 26, 21, 48, 16, 410, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 5, 26, 21, 48, 16, 410, DateTimeKind.Local).AddTicks(7665));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "DateCreated", "DrugName", "ExpiryDate", "ImageUrl", "price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 19, 22, 48, 14, 680, DateTimeKind.Local).AddTicks(886), "Acetaminophen", new DateTime(2084, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 421f },
                    { 2, new DateTime(2023, 5, 19, 22, 48, 14, 680, DateTimeKind.Local).AddTicks(902), "Doxycycline", new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 321f },
                    { 3, new DateTime(2023, 5, 19, 22, 48, 14, 680, DateTimeKind.Local).AddTicks(907), "Lexapro", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 401f },
                    { 4, new DateTime(2023, 5, 19, 22, 48, 14, 680, DateTimeKind.Local).AddTicks(909), "Pantoprazole", new DateTime(2031, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 921f },
                    { 5, new DateTime(2023, 5, 19, 22, 48, 14, 680, DateTimeKind.Local).AddTicks(910), "secukinumab", new DateTime(2027, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1123f },
                    { 6, new DateTime(2023, 5, 19, 22, 48, 14, 680, DateTimeKind.Local).AddTicks(912), "Wegovy", new DateTime(2052, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 891f }
                });

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
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}

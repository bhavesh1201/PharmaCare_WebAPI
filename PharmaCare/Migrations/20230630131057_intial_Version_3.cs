using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmaCare.Migrations
{
    /// <inheritdoc />
    public partial class intial_Version_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meesage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SuppilerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppilerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quntity = table.Column<int>(type: "int", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SuppilerId);
                    table.ForeignKey(
                        name: "FK_Suppliers_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "DateCreated", "DrugName", "ExpiryDate", "price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 30, 18, 40, 57, 486, DateTimeKind.Local).AddTicks(7950), "Acetaminophen", new DateTime(2084, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 421f },
                    { 2, new DateTime(2023, 6, 30, 18, 40, 57, 486, DateTimeKind.Local).AddTicks(7972), "Doxycycline", new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 321f },
                    { 3, new DateTime(2023, 6, 30, 18, 40, 57, 486, DateTimeKind.Local).AddTicks(7975), "Lexapro", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 401f },
                    { 4, new DateTime(2023, 6, 30, 18, 40, 57, 486, DateTimeKind.Local).AddTicks(7978), "Pantoprazole", new DateTime(2031, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 921f },
                    { 5, new DateTime(2023, 6, 30, 18, 40, 57, 486, DateTimeKind.Local).AddTicks(7981), "secukinumab", new DateTime(2027, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1123f },
                    { 6, new DateTime(2023, 6, 30, 18, 40, 57, 486, DateTimeKind.Local).AddTicks(7984), "Wegovy", new DateTime(2052, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 891f }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SuppilerId", "DrugId", "Email", "SuppilerName", "quntity" },
                values: new object[,]
                {
                    { 1, 1, "DavidWA@gmail.com ", "David Waxon", 0 },
                    { 2, 1, "Andk@gmail.com ", "Antony ", 0 },
                    { 3, 1, "JohnSc@gmail.com ", "Johan", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_DrugId",
                table: "Suppliers",
                column: "DrugId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmaCare.Data;

#nullable disable

namespace PharmaCare.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    partial class PharmacyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PharmaCare.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("PharmaCare.Models.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DrugName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Drugs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5201),
                            DrugName = "Acetaminophen",
                            ExpiryDate = new DateTime(2084, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 421f
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5217),
                            DrugName = "Doxycycline",
                            ExpiryDate = new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 321f
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5219),
                            DrugName = "Lexapro",
                            ExpiryDate = new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 401f
                        },
                        new
                        {
                            Id = 4,
                            DateCreated = new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5221),
                            DrugName = "Pantoprazole",
                            ExpiryDate = new DateTime(2031, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 921f
                        },
                        new
                        {
                            Id = 5,
                            DateCreated = new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5223),
                            DrugName = "secukinumab",
                            ExpiryDate = new DateTime(2027, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 1123f
                        },
                        new
                        {
                            Id = 6,
                            DateCreated = new DateTime(2023, 5, 22, 22, 31, 49, 122, DateTimeKind.Local).AddTicks(5225),
                            DrugName = "Wegovy",
                            ExpiryDate = new DateTime(2052, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 891f
                        });
                });

            modelBuilder.Entity("PharmaCare.Models.Supplier", b =>
                {
                    b.Property<int>("SuppilerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuppilerId"));

                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuppilerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuppilerId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SuppilerId = 1,
                            DrugId = 1,
                            Email = "DavidWA@gmail.com ",
                            SuppilerName = "David Waxon"
                        },
                        new
                        {
                            SuppilerId = 2,
                            DrugId = 1,
                            Email = "Andk@gmail.com ",
                            SuppilerName = "Antony "
                        },
                        new
                        {
                            SuppilerId = 3,
                            DrugId = 1,
                            Email = "JohnSc@gmail.com ",
                            SuppilerName = "Johan"
                        });
                });

            modelBuilder.Entity("PharmaCare.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

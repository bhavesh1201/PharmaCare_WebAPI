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

            modelBuilder.Entity("PharmaCare.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quntity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Carts");
                });

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
                            DateCreated = new DateTime(2023, 6, 30, 21, 33, 43, 218, DateTimeKind.Local).AddTicks(7102),
                            DrugName = "Acetaminophen",
                            ExpiryDate = new DateTime(2084, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 421f
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2023, 6, 30, 21, 33, 43, 218, DateTimeKind.Local).AddTicks(7132),
                            DrugName = "Doxycycline",
                            ExpiryDate = new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 321f
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2023, 6, 30, 21, 33, 43, 218, DateTimeKind.Local).AddTicks(7139),
                            DrugName = "Lexapro",
                            ExpiryDate = new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 401f
                        },
                        new
                        {
                            Id = 4,
                            DateCreated = new DateTime(2023, 6, 30, 21, 33, 43, 218, DateTimeKind.Local).AddTicks(7145),
                            DrugName = "Pantoprazole",
                            ExpiryDate = new DateTime(2031, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 921f
                        },
                        new
                        {
                            Id = 5,
                            DateCreated = new DateTime(2023, 6, 30, 21, 33, 43, 218, DateTimeKind.Local).AddTicks(7150),
                            DrugName = "secukinumab",
                            ExpiryDate = new DateTime(2027, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 1123f
                        },
                        new
                        {
                            Id = 6,
                            DateCreated = new DateTime(2023, 6, 30, 21, 33, 43, 218, DateTimeKind.Local).AddTicks(7155),
                            DrugName = "Wegovy",
                            ExpiryDate = new DateTime(2052, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 891f
                        });
                });

            modelBuilder.Entity("PharmaCare.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("meesage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("PharmaCare.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalItems")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PharmaCare.Models.Supplier", b =>
                {
                    b.Property<int>("SuppilerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuppilerId"));

                    b.Property<int?>("DrugId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuppilerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quntity")
                        .HasColumnType("int");

                    b.HasKey("SuppilerId");

                    b.HasIndex("DrugId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SuppilerId = 1,
                            DrugId = 1,
                            Email = "DavidWA@gmail.com ",
                            SuppilerName = "David Waxon",
                            quntity = 0
                        },
                        new
                        {
                            SuppilerId = 2,
                            DrugId = 1,
                            Email = "Andk@gmail.com ",
                            SuppilerName = "Antony ",
                            quntity = 0
                        },
                        new
                        {
                            SuppilerId = 3,
                            DrugId = 1,
                            Email = "JohnSc@gmail.com ",
                            SuppilerName = "Johan",
                            quntity = 0
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

            modelBuilder.Entity("PharmaCare.Models.Cart", b =>
                {
                    b.HasOne("PharmaCare.Models.Order", null)
                        .WithMany("Carts")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("PharmaCare.Models.Supplier", b =>
                {
                    b.HasOne("PharmaCare.Models.Drug", "Drugs")
                        .WithMany()
                        .HasForeignKey("DrugId");

                    b.Navigation("Drugs");
                });

            modelBuilder.Entity("PharmaCare.Models.Order", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}

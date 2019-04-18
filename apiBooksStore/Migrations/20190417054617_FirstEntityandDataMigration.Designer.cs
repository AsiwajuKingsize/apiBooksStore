﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiBooksStore.Data;

namespace apiBooksStore.Migrations
{
    [DbContext(typeof(BooksStoreContext))]
    [Migration("20190417054617_FirstEntityandDataMigration")]
    partial class FirstEntityandDataMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("BooksInventory")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apiBooksStore.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.Property<string>("Website");

                    b.HasKey("AuthorId");

                    b.ToTable("Author","BooksInventory");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorName = "Ifeanyi Chukwu",
                            Email = "chukwu@async.ae",
                            Phone = "+234018977655",
                            Website = "www.async.com"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorName = "William Shakespeare",
                            Email = "Shakespeare@gmail.com",
                            Phone = "+234018977655",
                            Website = "www.williamsShakespeareBooks.com"
                        },
                        new
                        {
                            AuthorId = 3,
                            AuthorName = "Joseph Okeke",
                            Email = "Okeke@gmail.com",
                            Phone = "+234018977655",
                            Website = "www.OkekeBooks.com"
                        });
                });

            modelBuilder.Entity("apiBooksStore.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<double>("Price");

                    b.Property<int?>("Quantity");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book","BooksInventory");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            Price = 0.0,
                            Title = "IT Systems"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            Price = 0.0,
                            Title = "King Lear"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 1,
                            Price = 0.0,
                            Title = "WEB PI Systems and Security"
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 3,
                            Price = 0.0,
                            Title = "Things Fall In Place"
                        });
                });

            modelBuilder.Entity("apiBooksStore.Models.BookSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<string>("Buyer");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("SaleDate");

                    b.HasKey("Id");

                    b.ToTable("BookSale","BooksInventory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Buyer = "Igwe Obi",
                            Quantity = 6,
                            SaleDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Buyer = "Chied Titus",
                            Quantity = 6,
                            SaleDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BookId = 1,
                            Buyer = "Osun Temidayo",
                            Quantity = 6,
                            SaleDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("apiBooksStore.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception");

                    b.Property<string>("Level");

                    b.Property<string>("LogEvent");

                    b.Property<string>("Message");

                    b.Property<string>("MessageTemplate");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Log","Logging");
                });

            modelBuilder.Entity("apiBooksStore.Models.Book", b =>
                {
                    b.HasOne("apiBooksStore.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

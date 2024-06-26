﻿// <auto-generated />
using System;
using BookstoreDBLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreDBLib.Migrations
{
    [DbContext(typeof(BookstoreDB))]
    [Migration("20240324190430_AddViewsPerYearColumn")]
    partial class AddViewsPerYearColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookstoreDBLib.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Анджей",
                            Surname = "Сапковський"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Джоан",
                            Surname = "Ролінґ"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Волтер",
                            Surname = "Тевіс"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Сюзанна",
                            Surname = "Коллінз"
                        });
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("Chapter")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsOnSale")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSequel")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsWriteOff")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int?>("PageCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PublishingHouseId")
                        .HasColumnType("int");

                    b.Property<string>("Reservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeriesId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecialOfferId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ViewsPerDay")
                        .HasColumnType("int");

                    b.Property<int?>("ViewsPerMonth")
                        .HasColumnType("int");

                    b.Property<int?>("ViewsPerWeek")
                        .HasColumnType("int");

                    b.Property<int?>("ViewsPerYear")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublishingHouseId");

                    b.HasIndex("SeriesId");

                    b.HasIndex("SpecialOfferId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 2,
                            Chapter = 1,
                            CostPrice = 250m,
                            GenreId = 1,
                            IsOnSale = true,
                            IsSequel = false,
                            IsWriteOff = false,
                            PageCount = 320,
                            Price = 320m,
                            PublishingHouseId = 3,
                            SeriesId = 1,
                            Title = "Гаррі Поттер і філософський камінь",
                            ViewsPerDay = 0,
                            ViewsPerMonth = 0,
                            ViewsPerWeek = 0,
                            ViewsPerYear = 0,
                            Year = 2002
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Chapter = 2,
                            CostPrice = 250m,
                            GenreId = 1,
                            IsOnSale = true,
                            IsSequel = true,
                            IsWriteOff = false,
                            PageCount = 352,
                            Price = 320m,
                            PublishingHouseId = 3,
                            SeriesId = 1,
                            Title = "Гаррі Поттер і таємна кімната",
                            ViewsPerDay = 0,
                            ViewsPerMonth = 0,
                            ViewsPerWeek = 0,
                            ViewsPerYear = 0,
                            Year = 2002
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CostPrice = 150m,
                            GenreId = 2,
                            IsOnSale = true,
                            IsSequel = false,
                            IsWriteOff = false,
                            PageCount = 352,
                            Price = 240m,
                            PublishingHouseId = 1,
                            Title = "Хід Королеви",
                            ViewsPerDay = 0,
                            ViewsPerMonth = 0,
                            ViewsPerWeek = 0,
                            ViewsPerYear = 0,
                            Year = 2021
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Chapter = 2,
                            CostPrice = 150m,
                            GenreId = 3,
                            IsOnSale = false,
                            IsSequel = true,
                            IsWriteOff = false,
                            PageCount = 352,
                            Price = 250m,
                            PublishingHouseId = 2,
                            SeriesId = 2,
                            Title = "Глодні Ігри",
                            ViewsPerDay = 0,
                            ViewsPerMonth = 0,
                            ViewsPerWeek = 0,
                            ViewsPerYear = 0,
                            Year = 2024
                        });
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Фентезі"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Роман"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Фантастика"
                        });
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.PublishingHouse", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PublishingHouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "КСД"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BookChief"
                        },
                        new
                        {
                            Id = 3,
                            Name = "А-ба-ба-га-ла-ма-га"
                        });
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.Series", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Series");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Гаррі Поттер"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Голодні Ігри"
                        });
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.SpecialOffer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SpecialOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discount = 20,
                            EndDate = new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "\"Енциклопедичний тиждень\": Знижка 25% на енциклопедії та словники",
                            StartDate = new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Discount = 20,
                            EndDate = new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "\"Літературні розпродажі\": Знижка 30% на бестселери",
                            StartDate = new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "vasyl.kushch@gmail.com",
                            Name = "Василь",
                            Password = "1234kv",
                            Surname = "Кущ"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ihor.smola@gmail.com",
                            Name = "Ігор",
                            Password = "1234is",
                            Surname = "Смола"
                        },
                        new
                        {
                            Id = 3,
                            Email = "dmytro.klymenko@gmail.com",
                            Name = "Дмитро",
                            Password = "1234dk",
                            Surname = "Клименко"
                        });
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.Book", b =>
                {
                    b.HasOne("BookstoreDBLib.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookstoreDBLib.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookstoreDBLib.Entities.PublishingHouse", "PublishingHouse")
                        .WithMany("Books")
                        .HasForeignKey("PublishingHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookstoreDBLib.Entities.Series", "Series")
                        .WithMany("Books")
                        .HasForeignKey("SeriesId");

                    b.HasOne("BookstoreDBLib.Entities.SpecialOffer", "SpecialOffer")
                        .WithMany("Books")
                        .HasForeignKey("SpecialOfferId");

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("PublishingHouse");

                    b.Navigation("Series");

                    b.Navigation("SpecialOffer");
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.PublishingHouse", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.Series", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookstoreDBLib.Entities.SpecialOffer", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

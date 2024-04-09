using Microsoft.EntityFrameworkCore;
using BookstoreDBLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDBLib
{
    public static class DbInitializer
    {
        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author
                {
                    Id = 1,
                    Name = "Анджей",
                    Surname = "Сапковський"
                },
                new Author
                {
                    Id = 2,
                    Name = "Джоан",
                    Surname = "Ролінґ"
                },
                new Author
                {
                    Id = 3,
                    Name = "Волтер",
                    Surname = "Тевіс"
                },
                new Author
                {
                    Id = 4,
                    Name = "Сюзанна",
                    Surname = "Коллінз"
                },
            });
        }

        public static void SeedPublishingHouses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublishingHouse>().HasData(new PublishingHouse[]
            {
                new PublishingHouse
                {
                    Id = 1,
                    Name = "КСД"
                },
                new PublishingHouse
                {
                    Id = 2,
                    Name = "BookChief"
                },
                new PublishingHouse
                {
                    Id = 3,
                    Name = "А-ба-ба-га-ла-ма-га"
                },
            });
        }

        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre
                {
                    Id = 1,
                    Name = "Фентезі"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Роман"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Фантастика"
                }
            });
        }

        public static void SeedSpecialOffers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecialOffer>().HasData(new SpecialOffer[]
            {
                new SpecialOffer
                {
                    Id = 1,
                    Name = "\"Енциклопедичний тиждень\": Знижка 25% на енциклопедії та словники",
                    Discount = 20,
                    StartDate = new DateTime(2024, 2, 23),
                    EndDate = new DateTime(2024, 5, 23),
                },
                new SpecialOffer
                {
                    Id = 2,
                    Name = "\"Літературні розпродажі\": Знижка 30% на бестселери",
                    Discount = 20,
                    StartDate = new DateTime(2024, 3, 22),
                    EndDate = new DateTime(2024, 3, 27),
                },
            });
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User
                {
                    Id = 1,
                    Name = "Василь",
                    Surname = "Кущ",
                    Email = "vasyl.kushch@gmail.com",
                    Password = "1234kv"
                },
                new User
                {
                    Id = 2,
                    Name = "Ігор",
                    Surname = "Смола",
                    Email = "ihor.smola@gmail.com",
                    Password = "1234is"
                },
                new User
                {
                    Id = 3,
                    Name = "Дмитро",
                    Surname = "Клименко",
                    Email = "dmytro.klymenko@gmail.com",
                    Password = "1234dk"
                },
            });
        }
        public static void SeedSeries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Series>().HasData(new Series[]
            {
                new Series
                {
                    Id = 1,
                    Name = "Гаррі Поттер"
                },
                new Series
                {
                    Id = 2,
                    Name = "Голодні Ігри"
                }
            });
        }

        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book
                {
                    Id = 1,
                    Title = "Гаррі Поттер і філософський камінь",
                    AuthorId = 2,
                    PublishingHouseId = 3,
                    PageCount = 320,
                    GenreId = 1,
                    Year = 2002,
                    CostPrice = 250,
                    Price = 320,
                    SeriesId = 1,
                    Chapter = 1,
                    IsOnSale = true,
                    IsWriteOff = false,
                },
                new Book
                {
                    Id = 2,
                    Title = "Гаррі Поттер і таємна кімната",
                    AuthorId = 2,
                    PublishingHouseId = 3,
                    PageCount = 352,
                    GenreId = 1,
                    Year = 2002,
                    CostPrice = 250,
                    Price = 320,
                    IsSequel = true,
                    SeriesId = 1,
                    Chapter = 2,
                    IsOnSale = true,
                    IsWriteOff = false,
                },
                new Book
                {
                    Id = 3,
                    Title = "Хід Королеви",
                    AuthorId = 3,
                    PublishingHouseId = 1,
                    PageCount = 352,
                    GenreId = 2,
                    Year = 2021,
                    CostPrice = 150,
                    Price = 240,
                    IsOnSale = true,
                    IsWriteOff = false,
                },
                new Book
                {
                    Id = 4,
                    Title = "Глодні Ігри",
                    AuthorId = 4,
                    PublishingHouseId = 2,
                    PageCount = 352,
                    GenreId = 3,
                    Year = 2024,
                    CostPrice = 150,
                    Price = 250,
                    SeriesId = 2,
                    IsSequel = true,
                    Chapter = 2,
                    IsOnSale = false,
                    IsWriteOff = false,
                },
            });
        }
    }
}

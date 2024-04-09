using Microsoft.EntityFrameworkCore;
using project_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class BookstoreDB : DbContext
    {
        public DbSet<Author> Authors;
        public DbSet<PublishingHouse> PublishingHouses;
        public DbSet<Genre> Genres;
        public DbSet<SpecialOffer> SpecialOffers;
        public DbSet<Book> Books;
        public DbSet<User> Users;

        public BookstoreDB()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NTTO45R\SQLEXPRESS;
                                          Initial Catalog=BookStore;
                                          Integrated Security=True;
                                          Connect Timeout=2;
                                          Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.PublishingHouse)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublishingHouseId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Series)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.SeriesId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.SpecialOffer)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.SpecialOfferId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.ReservationUser)
                .WithMany(u => u.ReservedBooks)
                .HasForeignKey(b => b.ReservationId);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Sellers)
                .WithOne(u => u.User)
                .HasForeignKey(s => s.UserId);

            modelBuilder.SeedAuthor();
            modelBuilder.SeedPublishingHouse();
            modelBuilder.SeedGenre();
            modelBuilder.SeedSeries();
            modelBuilder.SeedSpecialOffer();
            modelBuilder.SeedUser();
            modelBuilder.SeedSeller();
            modelBuilder.SeedBook();
        }
    }
}

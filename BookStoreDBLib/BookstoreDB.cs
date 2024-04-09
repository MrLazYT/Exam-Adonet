using Microsoft.EntityFrameworkCore;
using BookstoreDBLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDBLib
{
    public class BookstoreDB : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

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
                                          Encrypt = False;");
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
            
            modelBuilder.SeedAuthors();
            modelBuilder.SeedPublishingHouses();
            modelBuilder.SeedGenres();
            modelBuilder.SeedSeries();
            modelBuilder.SeedSpecialOffers();
            modelBuilder.SeedUsers();
            modelBuilder.SeedBooks();
        }
    }
}

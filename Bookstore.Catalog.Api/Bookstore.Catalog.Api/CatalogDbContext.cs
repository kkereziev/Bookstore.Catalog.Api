using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Catalog.Api
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Book>(b =>
            {
                // ISBN-ът е уникален за всяка книга в света, затова създаваме уникален индекс
                b.HasIndex(x => x.ISBN).IsUnique();
                // заглавието е задължително
                b.Property(x => x.Title).IsRequired();
                // уточняваме, че искаме цената да се съхранява в колона decimal(10,2)
                b.Property(x => x.Price).HasColumnType("decimal(10,2)");
                // опсиваме връзките на тази таблица с други таблици
                b.HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x =>
               x.PublisherID).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Language).WithMany(x => x.Books).HasForeignKey(x => x.LanguageID);
                b.HasMany(x => x.BookAuthors).WithOne(x => x.Book).HasForeignKey(x => x.BookID);
                b.HasMany(x => x.Genres).WithOne(x => x.Book).HasForeignKey(x => x.BookID);
            });

            mb.Entity<Author>(a =>
            {
                a.Property(x => x.FirstName).IsRequired();
                a.Property(x => x.LastName).IsRequired();
                a.HasMany(x => x.BookAuthors).WithOne(x => x.Author).HasForeignKey(x => x.AuthorID);
            });
            mb.Entity<Publisher>(p =>
            {
                p.Property(x => x.CompanyName).IsRequired();
                p.HasMany(x => x.Books).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherID);
            });
            mb.Entity<Genre>(g =>
            {
                g.Property(x => x.Name).IsRequired();
                g.HasMany(x => x.BookGenres).WithOne(x => x.Ganre).HasForeignKey(x => x.GenreID);
            });
            mb.Entity<BookAuthor>(ba =>
            {
                ba.HasKey(x => new { x.BookID, x.AuthorID });
            });
            mb.Entity<BookGenre>(bg =>
            {
                bg.HasKey(x => new { x.BookID, x.GenreID });
            });
        }
    }
}

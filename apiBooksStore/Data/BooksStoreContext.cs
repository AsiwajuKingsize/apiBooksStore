using apiBooksStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.Data
{
    public class BooksStoreContext : DbContext
    {
        public BooksStoreContext(DbContextOptions<BooksStoreContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<BookSale> BookSales { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                //Configure default schema
                modelBuilder.HasDefaultSchema("BooksInventory");

            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<BookSale>().ToTable("BookSale");

            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired().HasMaxLength(100);


            modelBuilder.Entity<Author>().HasMany(a => a.Books);



            modelBuilder.Entity<Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Price).IsRequired();


            modelBuilder.Entity<Book>().HasOne(b => b.Author);
              //.HasRequired(b ⇒ b.AuthorId)
              //.WithRequired(s ⇒ s.Author);

            modelBuilder.Entity<Author>().HasData(
                new Author{AuthorId=1, AuthorName = "Ifeanyi Chukwu", Email = "chukwu@async.ae", Phone = "+234018977655",
                     Website = "www.async.com"
                },
                new Author
                {
                    AuthorId = 2,
                    AuthorName = "William Shakespeare",
                    Email = "Shakespeare@gmail.com",
                    Phone = "+234018977655",
                    Website = "www.williamsShakespeareBooks.com"
                },
                new Author
                {
                    AuthorId = 3,
                    AuthorName = "Joseph Okeke",
                    Email = "Okeke@gmail.com",
                    Phone = "+234018977655",
                    Website = "www.OkekeBooks.com"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId=1, AuthorId = 1,Quantity=9 ,Title = "IT Systems" },
                new Book { BookId = 2, AuthorId = 2, Quantity = 19, Title = "King Lear" },
                new Book { BookId = 3, AuthorId = 1, Quantity = 11, Title = "WEB PI Systems and Security" },
                new Book { BookId = 4, AuthorId = 3, Quantity = 2, Title = "Things Fall In Place" }
            );

            modelBuilder.Entity<BookSale>().HasData(
                new BookSale { Id = 1, BookId = 1, Buyer= "Igwe Obi", Quantity = 6, SaleDate = Convert.ToDateTime("2019-01-01") },
            new BookSale { Id = 2, BookId = 1,  Buyer = "Chied Titus", Quantity = 6, SaleDate = Convert.ToDateTime("2019-01-01") },
            new BookSale { Id = 3, BookId = 1,  Buyer = "Osun Temidayo", Quantity = 6, SaleDate = Convert.ToDateTime("2019-01-01") }
            );


        }
    }
}

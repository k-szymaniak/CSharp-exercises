using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

namespace Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            context.Database.EnsureCreated();           
            IQueryable<Book> books = from book in context.Books
            where book.EditionYear > 2019
            select book;
            Console.WriteLine(string.Join("\n", books));

            var list = from book in context.Books
            join author in context.Authors
            on book.AuthorId equals author.Id
            where book.EditionYear > 2019
            select new { BookAuthor = author.Name, Title = book.Title };

            Console.WriteLine(string.Join("\n", list));

            list = context.Authors.Join(
                context.Books.Where(b => b.EditionYear > 2019),
                a => a.Id,
                b => b.AuthorId,
                (a , b) => new { BookAuthor = a.Name, Title = b.Title }
                );
            foreach (var item in list)
            {
                Console.WriteLine(item.BookAuthor);
            }

            var listcopy = from book in context.Books
                       join bookcopy in context.BookCopies
                       on book.Id equals bookcopy.BookId
                       select new { UniqueNumber = bookcopy.UniqueNumber, Title = book.Title };

            Console.WriteLine(string.Join("\n", listcopy));
        }
        string xml =
            "<books>" +
                "<book>" +
                    "<id>1</id>" +
                    "<title>c#</title>" +
                "</book>" +
                "<book>" +
                    "<id>2</id>" +
                    "<title>JAVA</title>" +
                "</book>" +
            "</books>";
        XDocument doc = XDocument.Parse(xml);
            System.Collections.Generic.IEnumerable<XElement> booksId = XDocument
            .Elements("books")
            .Elements("book")
    }

    public record Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EditionYear { get; set; }
        public int AuthorId { get; set; }
    }
    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public record BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UniqueNumber { get; set; }
    }

    class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATASOURCE=d:\\database2\\base.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("books")
                .HasData(
                new Book() { Id = 1, AuthorId = 1, EditionYear = 2020, Title = "C++"},
                new Book() { Id = 2, AuthorId = 1, EditionYear = 2019, Title = "JAVA" },
                new Book() { Id = 3, AuthorId = 2, EditionYear = 2015, Title = "HTML" },
                new Book() { Id = 4, AuthorId = 2, EditionYear = 2022, Title = "C#" }
                );

            modelBuilder.Entity<Author>()
              .ToTable("authors")
              .HasData(
              new Author() {Id = 1, Name = "Adam"},
              new Author() { Id = 2, Name = "Piotr" }

              );

            modelBuilder.Entity<BookCopy>()
              .ToTable("bookcopies")
              .HasData(
              new BookCopy() { Id = 1, BookId = 3, UniqueNumber ="QEQWRFZFFSFSFSF"},
              new BookCopy() { Id = 1, BookId = 4, UniqueNumber ="FAFAW1FAFAFAFAF"}


              );
        }
    }
}

using BookCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Data
{
    public class DataSeeder
    {
        public static async Task SeedData(
           BooksDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            await CreateSampleBooks(dbContext);
        }

        private static async Task CreateSampleBooks(BooksDbContext dbContext)
        {
            //Dodaj dane tylko kiedy tabela z książkami jest pusta (w celach demonstracyjnych)
            var booksArePresentInTheTable = dbContext.Books.Any();

            if (booksArePresentInTheTable)
                return;

            var placeholderBooks = new List<Book>
            {
                new Book
                {
                    Title = "Tytuł 1",
                    PublishDate = new DateTime(2022,01,17),
                    NumberOfPages = 100,
                    CatalogNumber = "ABC",
                    IsRented = false
                },
                new Book
                {
                    Title = "Tytuł 2",
                    PublishDate = new DateTime(2010,04,14),
                    NumberOfPages = 999,
                    CatalogNumber = "DEF",
                    IsRented = false
                },
                new Book
                {
                    Title = "Tytuł 3",
                    PublishDate = new DateTime(2021,12,1),
                    NumberOfPages = 2300,
                    CatalogNumber = "GHI",
                    IsRented = true
                }
            };

            dbContext.Books.AddRange(placeholderBooks);

            await dbContext.SaveChangesAsync();
        }
    }
}

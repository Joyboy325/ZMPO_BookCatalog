using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}

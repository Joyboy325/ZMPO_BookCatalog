using BookCatalog.Data;
using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCatalog.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksDbContext _booksContext;

        public BooksRepository(BooksDbContext books)
        {
            this._booksContext = books;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIDAsync(int id)
        {
            return await _booksContext.Books.FindAsync(id);
        }

        public async Task InsertBookAsync(Book book)
        {
            await _booksContext.Books.AddAsync(book);
        }

        public void DeleteBook(int bookId)
        {
            Book book = _booksContext.Books.Find(bookId);
            _booksContext.Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            _booksContext.Entry(book).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _booksContext.SaveChangesAsync();
        }
    }
}

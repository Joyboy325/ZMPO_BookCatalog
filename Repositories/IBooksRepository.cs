using BookCatalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCatalog.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIDAsync(int bookId);
        Task InsertBookAsync(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book);
        Task SaveAsync();
    }
}

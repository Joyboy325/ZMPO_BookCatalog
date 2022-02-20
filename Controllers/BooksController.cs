using BookCatalog.Models;
using BookCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _booksRepository.GetAllBooksAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _booksRepository.GetBookByIDAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PublishDate,NumberOfPages,CatalogNumber,IsRented,RentalStartDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Title = book.Title.Trim();
                await _booksRepository.InsertBookAsync(book);
                await _booksRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _booksRepository.GetBookByIDAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PublishDate,NumberOfPages,CatalogNumber,IsRented,RentalStartDate")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _booksRepository.UpdateBook(book);
                    await _booksRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExistsAsync(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _booksRepository.GetBookByIDAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _booksRepository.DeleteBook(id);
            await _booksRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExistsAsync(int id)
        {
            var allBooks = await _booksRepository.GetAllBooksAsync();
            return allBooks.Any(e => e.Id == id);
        }
    }
}

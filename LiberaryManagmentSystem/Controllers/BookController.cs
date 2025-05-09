using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LiberaryManagmentSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /Book
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        // GET: /Book/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // GET: /Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid) return View(book);

            await _bookService.AddAsync(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Book/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Book/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid) return View(book);

            var updated = await _bookService.UpdateAsync(book);
            if (!updated) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Book/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Book/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();

            await _bookService.DeleteAsync(book);
            return RedirectToAction(nameof(Index));
        }

        // Optional: Filter Action
        public async Task<IActionResult> Filter(bool? isBorrowed, DateTime? borrowDate, DateTime? returnDate)
        {
            var books = await _bookService.FilterBooksAsync(isBorrowed, borrowDate, returnDate);
            return View("Index", books);
        }
    }
}

using AutoMapper;
using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Services.Implementation;
using LiberaryManagmentSystem.Services.Interfaces;
using LiberaryManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace LiberaryManagmentSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IAuthorService authorService,IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _mapper = mapper;
        }

        // GET: /Book
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            var bookViewModels = _mapper.Map<IEnumerable<BookViewModel>>(books);
            return View(bookViewModels);
        }

        // GET: /Book/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // GET: /Book/Create
        public async Task <IActionResult> Create()
        {

            var authors = await _authorService.GetAllAsync();

            var viewModel = new BookFormViewModel
            {
                Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.FullName
                })
            };

            return View(viewModel);
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel BookFormViewModel)
        {
            if (!ModelState.IsValid) return View(BookFormViewModel);
            var book = _mapper.Map<Book>(BookFormViewModel);
            await _bookService.AddAsync(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Book/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            var bookFormViewModels = _mapper.Map<BookFormViewModel>(book);
            var authors = await _authorService.GetAllAsync();
            bookFormViewModels.Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FullName
            });
            return View(bookFormViewModels);
        }

        // POST: /Book/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookFormViewModel BookFormViewModel)
        {
            if (!ModelState.IsValid) return View(BookFormViewModel);
            var book = _mapper.Map<Book>(BookFormViewModel);
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
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteAsync(id);
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

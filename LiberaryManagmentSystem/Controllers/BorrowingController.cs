using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Services.Interfaces;
using LiberaryManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LiberaryManagmentSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BorrowingTransactionController : Controller
    {
        private readonly IBorrowingTransactionService _borrowingTransactionService;
        private readonly IBookService _bookService;

        public BorrowingTransactionController(IBorrowingTransactionService borrowingTransactionService, IBookService bookService)
        {
            _borrowingTransactionService = borrowingTransactionService;
            _bookService = bookService;
        }

        // GET: /BorrowingTransaction/BorrowBook
      public async Task<IActionResult> BorrowBook()
{
    var allBooks = await _bookService.GetAllAsync();
    var availableBooks = new List<SelectListItem>();

    foreach (var book in allBooks)
    {
        var activeTransaction = await _borrowingTransactionService.GetActiveTransactionByBookIdAsync(book.Id);
        if (activeTransaction == null || activeTransaction.ReturnedDate != null)
        {
            availableBooks.Add(new SelectListItem
            {
                Value = book.Id.ToString(),
                Text = book.Title
            });
        }
    }

    var viewModel = new BorrowBookViewModel
    {
        Books = availableBooks,
        BookOptions = new SelectList(availableBooks, "Value", "Text")
    };

    return View(viewModel);
}


        // POST: /BorrowingTransaction/BorrowBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrowBook(BorrowBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var books = await _bookService.GetAllAsync();
                model.Books = books.Select(book => new SelectListItem
                {
                    Value = book.Id.ToString(),
                    Text = book.Title
                });
                return View(model);
            }

            var book = await _bookService.GetByIdAsync(model.BookId);
            if (book == null)
            {
                ModelState.AddModelError("", "The selected book does not exist.");
                return View(model);
            }

            var activeTransaction = await _borrowingTransactionService.GetActiveTransactionByBookIdAsync(model.BookId);
            if (activeTransaction != null && activeTransaction.ReturnedDate == null)
            {
                ModelState.AddModelError("", "The selected book is already borrowed.");
                return View(model);
            }
       

            var transaction = new BorrowingTransaction
            {
                BookId = model.BookId,
                BorrowedDate = model.BorrowedDate,
                DueDate = model.BorrowedDate.AddDays(14),
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            await _borrowingTransactionService.AddAsync(transaction);

            return RedirectToAction("MyTransactions");
        }

        // GET: /BorrowingTransaction/ReturnBook/{id}
        public async Task<IActionResult> ReturnBook(int id)
        {
            var transaction = await _borrowingTransactionService.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            if (transaction.ReturnedDate != null)
            {
                return RedirectToAction("MyTransactions");
            }

            transaction.ReturnedDate = DateTime.Now;
            await _borrowingTransactionService.UpdateAsync(transaction);

            return RedirectToAction("MyTransactions");
        }


        // GET: /BorrowingTransaction/MyTransactions
        public async Task<IActionResult> MyTransactions()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var transactions = await _borrowingTransactionService.GetByUserIdAsync(userId); // Note: update service to accept string

            var borrowingViewModels = transactions.Select(transaction => new BorrowingViewModel
            {
                Id = transaction.Id,
                BookTitle = transaction.Book?.Title ?? "Unknown",
                AuthorName = transaction.Book?.Author?.FullName ?? "Unknown",
                BorrowedDate = transaction.BorrowedDate,
                ReturnedDate = transaction.ReturnedDate
            }).ToList();

            return View(borrowingViewModels);
        }


    }
}

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
        public IActionResult Index()
        {
            return View();
        }
    }
}

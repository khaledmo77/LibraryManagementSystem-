using LiberaryManagmentSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiberaryManagmentSystem.Controllers
{
    public class TestController : Controller
    {
        private readonly LibraryDbContext _context;
        
        public TestController(LibraryDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var authors = _context.Authors.ToList();
            var books = _context.Books.ToList();


            return Json(new { Authors = authors, Books = books });
        }
    }
}

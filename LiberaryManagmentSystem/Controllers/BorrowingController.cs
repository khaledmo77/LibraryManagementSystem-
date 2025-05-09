using LiberaryManagmentSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LiberaryManagmentSystem.Controllers
{
    public class BorrowingController : Controller
    {
        private readonly IBorrowingTransactionService _transactionService;
        public BorrowingController(IBorrowingTransactionService transactionService)
        {
           _transactionService = transactionService; 
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Services.Interfaces;
using LiberaryManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LiberaryManagmentSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        //GET:Authors 
        public async Task<IActionResult> Index()
        {
            var authors= await _authorService.GetAllAsync();
            return View(authors);
        }
        //GET:Create
        public IActionResult Create()
        {
            return View();
        }
        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorViewModel author)//will be error here i didn't cast in repo
        {
            if (!ModelState.IsValid)
                return View(author);
            if (!await _authorService.IsEmailUniqueAsync(author.Email))
            {
                ModelState.AddModelError("Email", "This email is already in use.");
                return View(author);
            }

            if (!await _authorService.IsNameUniqueAsync(author.FullName))
            {
                ModelState.AddModelError("FullName", "This name is already in use.");
                return View(author);
            }


            await _authorService.AddAsync(author);
            return RedirectToAction(nameof(Index));
        }
        //GET: Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {

            var author = await _authorService.GetByIdAsync(id);
            if (author == null) return NotFound();
            return View(author);
        }
        // POST: Authors/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuthorViewModel author)
        {
            if (id != author.Id || !ModelState.IsValid)
                return View(author);
            if (!await _authorService.IsEmailUniqueAsync(author.Email, author.Id))
            {
                ModelState.AddModelError("Email", "This email is already in use.");
                return View(author);
            }

            if (!await _authorService.IsNameUniqueAsync(author.FullName, author.Id))
            {
                ModelState.AddModelError("FullName", "This name is already in use.");
                return View(author);
            }
            await _authorService.UpdateAsync(author.Id,author);
            return RedirectToAction(nameof(Index));
        }
        // GET: Authors/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null) return NotFound();
            return View(author);
        }
        // POST: Authors/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _authorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        // GET: Authors/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorService.GetAuthorWithBooksAsync(id);
            return View(author);
        }

    }
}

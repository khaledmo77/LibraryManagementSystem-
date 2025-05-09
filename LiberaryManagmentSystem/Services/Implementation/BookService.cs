using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Repositories.Interfaces;
using LiberaryManagmentSystem.Services.Interfaces;
using LiberaryManagmentSystem.ViewModels;

namespace LiberaryManagmentSystem.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepo.GetAllAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepo.GetByIdAsync(id);
        }

        public async Task AddAsync(Book book)
        {
             await _bookRepo.AddAsync(book);
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            var exists = await _bookRepo.ExistsAsync(book.Id);
            if (!exists) return false;

            await _bookRepo.UpdateAsync(book);
            return true;
        }

        public async Task<bool> DeleteAsync(Book book)
        {
            var exists = await _bookRepo.ExistsAsync(book.Id);
            if (!exists) return false;

            await _bookRepo.DeleteAsync(book);
            return true;
        }

        public async Task<IEnumerable<Book>> FilterBooksAsync(bool? isBorrowed, DateTime? borrowDate, DateTime? returnDate)
        {
            return await _bookRepo.FilterBooksAsync(isBorrowed, borrowDate, returnDate);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _bookRepo.ExistsAsync(id);
        }
    }
        
}

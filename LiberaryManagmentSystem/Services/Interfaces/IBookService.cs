using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.ViewModels;

namespace LiberaryManagmentSystem.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(Book book);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Book>> FilterBooksAsync(bool? isBorrowed, DateTime? borrowDate, DateTime? returnDate);
    }
}
  


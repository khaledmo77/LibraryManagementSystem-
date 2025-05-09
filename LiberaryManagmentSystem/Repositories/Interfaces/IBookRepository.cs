using LiberaryManagmentSystem.Models;

namespace LiberaryManagmentSystem.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
        Task<IEnumerable<Book>> FilterBooksAsync(bool? isBorrowed, DateTime? borrowDate, DateTime? returnDate);
        Task<bool> ExistsAsync(int id);
    }
}

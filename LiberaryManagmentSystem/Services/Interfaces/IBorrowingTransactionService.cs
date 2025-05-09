using LiberaryManagmentSystem.Models;

namespace LiberaryManagmentSystem.Services.Interfaces
{
    public interface IBorrowingTransactionService
    {
        Task<IEnumerable<BorrowingTransaction>> GetAllAsync();
        Task<BorrowingTransaction?> GetByIdAsync(int id);
        Task<BorrowingTransaction?> GetActiveTransactionByBookIdAsync(int bookId);
        Task<IEnumerable<BorrowingTransaction>> GetByUserIdAsync(int userId);
        Task<IEnumerable<BorrowingTransaction>> GetOverdueTransactionsAsync();
        Task AddAsync(BorrowingTransaction transaction);
        Task UpdateAsync(BorrowingTransaction transaction);
        Task DeleteAsync(int id);
    }
}

using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Repositories.Interfaces;
using LiberaryManagmentSystem.Services.Interfaces;

namespace LiberaryManagmentSystem.Services
{
    public class BorrowingTransactionService : IBorrowingTransactionService
    {
        private readonly IBorrowingTransactionRepository _repository;

        public BorrowingTransactionService(IBorrowingTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BorrowingTransaction>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<BorrowingTransaction?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<BorrowingTransaction?> GetActiveTransactionByBookIdAsync(int bookId)
        {
            return await _repository.GetActiveTransactionByBookIdAsync(bookId);
        }

        public async Task<IEnumerable<BorrowingTransaction>> GetByUserIdAsync(string userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<BorrowingTransaction>> GetOverdueTransactionsAsync()
        {
            return await _repository.GetOverdueTransactionsAsync();
        }

        public async Task AddAsync(BorrowingTransaction transaction)
        {
            await _repository.AddAsync(transaction);
        }

        public async Task UpdateAsync(BorrowingTransaction transaction)
        {
            await _repository.UpdateAsync(transaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

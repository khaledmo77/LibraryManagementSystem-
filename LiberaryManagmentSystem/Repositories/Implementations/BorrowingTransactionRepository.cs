using LiberaryManagmentSystem.Data;
using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class BorrowingTransactionRepository : IBorrowingTransactionRepository
{
    private readonly ApplicationDbContext _context;

    public BorrowingTransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BorrowingTransaction>> GetAllAsync()
    {
        return await _context.BorrowingTransactions
            .Include(t => t.Book)
            .ThenInclude(b => b.Author)
            .ToListAsync();
    }

    public async Task<BorrowingTransaction?> GetByIdAsync(int id)
    {
        return await _context.BorrowingTransactions
            .Include(t => t.Book)
            .ThenInclude(b => b.Author)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<BorrowingTransaction?> GetActiveTransactionByBookIdAsync(int bookId)
    {
        return await _context.BorrowingTransactions
            .FirstOrDefaultAsync(t => t.BookId == bookId && t.ReturnedDate == null);
    }

    public async Task AddAsync(BorrowingTransaction transaction)
    {
        var activeTransaction = await _context.BorrowingTransactions
            .Where(t => t.BookId == transaction.BookId && t.ReturnedDate == null)
            .FirstOrDefaultAsync();

        if (activeTransaction != null)
        {
            throw new InvalidOperationException("This book is currently borrowed and has not been returned.");
        }
        await _context.BorrowingTransactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BorrowingTransaction transaction)
    {
        _context.BorrowingTransactions.Update(transaction);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<BorrowingTransaction>> GetByUserIdAsync(string userId)
    {
        return await _context.BorrowingTransactions
         .Include(t => t.Book)
             .ThenInclude(b => b.Author)
         .Where(t => t.UserId == userId)
         .ToListAsync();
    }
   public async Task<IEnumerable<BorrowingTransaction>> GetOverdueTransactionsAsync()
    {
        var today = DateTime.UtcNow;
        return await _context.BorrowingTransactions
            .Include(t => t.Book)
            .ThenInclude(b => b.Author)
            .Where(t => t.DueDate < today && t.ReturnedDate == null)
            .ToListAsync();

    }
   public async Task DeleteAsync(int id)
    {
        var transaction = await _context.BorrowingTransactions.FindAsync(id);
        if (transaction != null)
        {
            _context.BorrowingTransactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}

using LiberaryManagmentSystem.Data;
using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LiberaryManagmentSystem.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
            public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Books.AnyAsync(b => b.Id == id);
    }
        public async Task<IEnumerable<Book>> FilterBooksAsync(bool? isBorrowed, DateTime? borrowDate, DateTime? returnDate)
        {
            var booksQuery = _context.Books.Include(b => b.Author).AsQueryable();
            if (isBorrowed.HasValue)
            {
                var borrowedBookIds = await _context.BorrowingTransactions
                    .Where(t => t.ReturnedDate == null)
                    .Select(t => t.BookId)
                    .ToListAsync();

                booksQuery = isBorrowed.Value
                    ? booksQuery.Where(b => borrowedBookIds.Contains(b.Id))
                    : booksQuery.Where(b => !borrowedBookIds.Contains(b.Id));
            }
            if (borrowDate.HasValue)
            {
                var borrowedBookIds = await _context.BorrowingTransactions
                    .Where(t => t.BorrowedDate.Date == borrowDate.Value.Date)
                    .Select(t => t.BookId)
                    .ToListAsync();

                booksQuery = booksQuery.Where(b => borrowedBookIds.Contains(b.Id));
            }

            if (returnDate.HasValue)
            {
                var returnedBookIds = await _context.BorrowingTransactions
                    .Where(t => t.ReturnedDate.HasValue && t.ReturnedDate.Value.Date == returnDate.Value.Date)
                    .Select(t => t.BookId)
                    .ToListAsync();

                booksQuery = booksQuery.Where(b => returnedBookIds.Contains(b.Id));
            }

            return await booksQuery.ToListAsync();
        }
    }
}

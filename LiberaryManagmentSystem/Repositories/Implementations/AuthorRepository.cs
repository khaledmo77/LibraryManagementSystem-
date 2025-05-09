using LiberaryManagmentSystem.Data;
using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LiberaryManagmentSystem.Repositories.Implementations
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
           return await _context.Authors.AsNoTracking().ToListAsync();
        }
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        } 
        public async Task AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var Author = await _context.Authors.FindAsync(id);
            if (Author != null)
            { 
                _context.Authors.Remove(Author);
             await   _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
       public async Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null)
        {
            return !await _context.Authors
             .AnyAsync(a => a.Email == email && (!excludeId.HasValue || a.Id != excludeId));
        }
        public async Task<bool> IsFullNameUniqueAsync(string FullName, int? excludeId = null)
        {
            return !await _context.Authors
             .AnyAsync(a => a.FullName == FullName && (!excludeId.HasValue || a.Id != excludeId));
        }
        public async Task<Author?> GetAuthorWithBookAsync(int id)
        {
            return await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}

using LiberaryManagmentSystem.Models;

namespace LiberaryManagmentSystem.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task AddAsync(Author author);
        Task DeleteAsync(int id);
        Task UpdateAsync(Author author);
        Task<bool>IsFullNameUniqueAsync(string name, int? excludeId = null);
        Task<bool>IsEmailUniqueAsync(string email, int? excludeId = null);
        Task<Author?> GetAuthorWithBookAsync(int id);

    }
}

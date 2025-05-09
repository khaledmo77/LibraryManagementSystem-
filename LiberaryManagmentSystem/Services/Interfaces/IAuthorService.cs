using LiberaryManagmentSystem.ViewModels;

namespace LiberaryManagmentSystem.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorViewModel>> GetAllAsync();
        Task<AuthorViewModel> GetByIdAsync(int id);
        Task<AuthorDetailsViewModel> GetAuthorWithBooksAsync(int id);
        Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null);
        Task<bool> IsNameUniqueAsync(string fullName, int? excludeId = null);
        Task AddAsync(AuthorViewModel model);
        Task UpdateAsync(int id, AuthorViewModel model);
        Task DeleteAsync(int id);
    }

}

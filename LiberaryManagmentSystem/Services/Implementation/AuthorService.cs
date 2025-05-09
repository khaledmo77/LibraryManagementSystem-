using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Repositories.Interfaces;
using LiberaryManagmentSystem.Services.Interfaces;
using LiberaryManagmentSystem.ViewModels;

namespace LiberaryManagmentSystem.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return authors.Select(a => new AuthorViewModel
            {
                Id = a.Id,
                FullName = a.FullName,
                Email = a.Email,
                Website = a.Website,
                Bio = a.Bio
            });
        }

        public async Task<AuthorViewModel> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return null;

            return new AuthorViewModel
            {
                Id = author.Id,
                FullName = author.FullName,
                Email = author.Email,
                Website = author.Website,
                Bio = author.Bio
            };
        }

        public async Task<AuthorDetailsViewModel> GetAuthorWithBooksAsync(int id)
        {
            var author = await _authorRepository.GetAuthorWithBookAsync(id);
            if (author == null) return null;

            return new AuthorDetailsViewModel
            {
                Id = author.Id,
                FullName = author.FullName,
                Email = author.Email,
                Website = author.Website,
                Bio = author.Bio,
                Books = author.Books.Select(b => new BookMiniViewModel
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList()
            };
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null)
        {
            var existing = await _authorRepository.GetAllAsync();
            return !existing.Any(a => a.Email == email && a.Id != excludeId);
        }

        public async Task<bool> IsNameUniqueAsync(string fullName, int? excludeId = null)
        {
            var existing = await _authorRepository.GetAllAsync();
            return !existing.Any(a => a.FullName == fullName && a.Id != excludeId);
        }

        public async Task AddAsync(AuthorViewModel model)
        {
            var author = new Author
            {
                FullName = model.FullName,
                Email = model.Email,
                Website = model.Website,
                Bio = model.Bio
            };

            await _authorRepository.AddAsync(author);
        }

        public async Task UpdateAsync(int id, AuthorViewModel model)
        {
            var existing = await _authorRepository.GetByIdAsync(id);
            if (existing == null) return;

            existing.FullName = model.FullName;
            existing.Email = model.Email;
            existing.Website = model.Website;
            existing.Bio = model.Bio;

            await _authorRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _authorRepository.DeleteAsync(id);
        }
    }

}

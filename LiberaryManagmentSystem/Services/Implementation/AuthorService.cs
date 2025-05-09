using AutoMapper;
using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.Repositories.Interfaces;
using LiberaryManagmentSystem.Services.Interfaces;
using LiberaryManagmentSystem.ViewModels;

namespace LiberaryManagmentSystem.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorViewModel>>(authors);
        }

        public async Task<AuthorViewModel> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id)
           ?? throw new KeyNotFoundException("Author not found."); ;

            return _mapper.Map<AuthorViewModel>(author);
        }

        public async Task<AuthorDetailsViewModel> GetAuthorWithBooksAsync(int id)
        {
            var author = await _authorRepository.GetAuthorWithBookAsync(id)
                 ?? throw new KeyNotFoundException("Author not found.");

            return _mapper.Map<AuthorDetailsViewModel>(author);
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
            var author = _mapper.Map<Author>(model);
            await _authorRepository.AddAsync(author);
        }

        public async Task UpdateAsync(int id, AuthorViewModel model)
        {
            var existing = await _authorRepository.GetByIdAsync(id);
            if (existing == null) return;
            _mapper.Map(model, existing);

            await _authorRepository.UpdateAsync(existing);
        }   

        public async Task DeleteAsync(int id)
        {
            await _authorRepository.DeleteAsync(id);
        }

    }

}

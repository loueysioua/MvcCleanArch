using System.Linq.Expressions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcCleanArch.Domain.Interfaces;
using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Infrastructure.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IGenericRepository<Genre> _genericRepository;
        public GenreRepository(IGenericRepository<Genre> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task AddAsync(Genre genre)
        {
            await _genericRepository.AddAsync(genre);
        }

        public async Task DeleteAsync(Guid id)
        {
            var genre = await _genericRepository.GetByIdAsync(id);
            if (genre != null)
            {
                await _genericRepository.DeleteAsync(genre);
            }
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<Genre> GetByIdAsync(Guid id)
        {
            var genre = await _genericRepository.GetByIdAsync(id);
            if (genre == null)
            {
                throw new KeyNotFoundException($"Genre with id {id} not found.");
            }
            return genre;
        }

        public async Task UpdateAsync(Genre genre)
        {
            await _genericRepository.UpdateAsync(genre);
        }




    }
}
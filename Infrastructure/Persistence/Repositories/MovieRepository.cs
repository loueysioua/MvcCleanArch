using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcCleanArch.Domain.Interfaces;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Infrastructure.Persistence.DbContext;

namespace MvcCleanArch.Infrastructure.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IGenericRepository<Movie> _genericRepository;
        public MovieRepository(IGenericRepository<Movie> genericRepository, ApplicationDbContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task AddAsync(Movie movie)
        {
            await _genericRepository.AddAsync(movie);
        }

        public async Task DeleteAsync(Guid id)
        {
            var movie = await _genericRepository.GetByIdAsync(id);
            if (movie != null)
            {
                await _genericRepository.DeleteAsync(movie);
            }
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var movies = await _dbContext.Movies.Include(m => m.Genre).ToListAsync();
            return movies;
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            var movie = await _dbContext.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id {id} not found.");
            }
            return movie;
        }

        public async Task UpdateAsync(Movie movie)
        {
            await _genericRepository.UpdateAsync(movie);
        }

    }
}
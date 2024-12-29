using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Domain.Interfaces;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Infrastructure.Persistence.DbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCleanArch.Infrastructure.Persistence.Repositories
{
    public class MovieUserRepository : IMovieUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<MovieUser> _genericRepository;

        public MovieUserRepository(IGenericRepository<MovieUser> genericRepository, ApplicationDbContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task AddAsync(MovieUser movieUser)
        {
            await _genericRepository.AddAsync(movieUser);
        }

        public async Task DeleteAsync(Guid id)
        {
            var movieUser = await _genericRepository.GetByIdAsync(id);
            if (movieUser != null)
            {
                await _genericRepository.DeleteAsync(movieUser);
            }
        }

        public async Task<IEnumerable<MovieUser>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<IEnumerable<MovieUser>> GetFavoritesAsync()
        {
            return await _dbContext.MoviesUsers.Include(mu => mu.Movie).Include(mu => mu.User).Where(mu => mu.IsFavourite).ToListAsync();
        }

        public async Task<MovieUser> GetByIdAsync(Guid movieId, string userId)
        {
            return await _dbContext.MoviesUsers.Include(mu => mu.Movie).Include(mu => mu.User).FirstOrDefaultAsync(mu => mu.MovieId == movieId && mu.UserId == userId);
        }

        public async Task UpdateAsync(MovieUser movieUser)
        {
            await _genericRepository.UpdateAsync(movieUser);
        }


    }
}
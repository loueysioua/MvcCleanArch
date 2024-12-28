using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Domain.Interfaces;
using MvcCleanArch.Infrastructure.Persistence.DbContext;


namespace MvcCleanArch.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        protected readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext mvcMovieRepoContext)
        {
            _dbContext = mvcMovieRepoContext;
            _dbSet = mvcMovieRepoContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
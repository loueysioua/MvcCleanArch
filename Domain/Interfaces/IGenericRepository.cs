using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<AppUser> GetByIdAsync(string id);
    }
}
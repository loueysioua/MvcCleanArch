using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<MovieUser>> GetAllAsync();
        Task<Genre> GetByIdAsync(Guid id);
        Task AddAsync(AppUser user);
        Task UpdateAsync(AppUser user);
        Task DeleteAsync(Guid id);
    }
}
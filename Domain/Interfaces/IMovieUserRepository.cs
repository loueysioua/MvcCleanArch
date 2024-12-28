using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Domain.Interfaces
{
    public interface IMovieUserRepository
    {
        Task<IEnumerable<MovieUser>> GetAllAsync();
        Task<IEnumerable<MovieUser>> GetFavoritesAsync();
        Task<Genre> GetByIdAsync(Guid id);
        Task AddAsync(MovieUser movieUser);
        Task UpdateAsync(MovieUser movieUser);
        Task DeleteAsync(Guid id);
    }
}
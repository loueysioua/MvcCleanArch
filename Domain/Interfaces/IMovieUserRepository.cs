using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Domain.Interfaces
{
    public interface IMovieUserRepository
    {
        Task<IEnumerable<MovieUser>> GetAllAsync();
        Task<IEnumerable<MovieUser>> GetFavoritesAsync();
        Task<MovieUser> GetByIdAsync(Guid movieId, string userId);
        Task AddAsync(MovieUser movieUser);
        Task UpdateAsync(MovieUser movieUser);
        Task DeleteAsync(Guid id);
    }
}
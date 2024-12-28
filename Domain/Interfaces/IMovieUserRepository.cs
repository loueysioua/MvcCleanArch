using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Domain.Interfaces
{
    public interface IMovieUserRepository
    {
        Task<IEnumerable<MovieUser>> GetAllAsync();
        Task<IEnumerable<MovieUser>> GetFavoritesAsync();
        Task<Genre> GetByIdAsync(Guid id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Guid id);
    }
}
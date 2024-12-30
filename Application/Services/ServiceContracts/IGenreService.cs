using MvcCleanArch.Application.DTOs.GenreDtos;
using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Application.Services.ServiceContracts
{
  public interface IGenreService
  {
    Task<IEnumerable<Genre>> GetAllGenresAsync();
    Task<Genre?> GetGenreByIdAsync(Guid id);
    Task<Genre> CreateGenreAsync(CreateGenreDto createGenreDto);
    Task<Genre> UpdateGenreAsync(Guid genreId, UpdateGenreDto updateGenreDto);
    Task DeleteGenreAsync(Guid id);
  }
}
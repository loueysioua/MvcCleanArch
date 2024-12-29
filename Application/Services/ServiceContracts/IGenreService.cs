using MvcCleanArch.Application.DTOs.GenreDtos;

namespace MvcCleanArch.Application.Services.ServiceContracts
{
  public interface IGenreService
  {
    Task<IEnumerable<GenreDto>> GetAllGenresAsync();
    Task<GenreDto?> GetGenreByIdAsync(Guid id);
    Task<GenreDto> CreateGenreAsync(CreateGenreDto createGenreDto);
    Task<GenreDto> UpdateGenreAsync(Guid genreId, UpdateGenreDto updateGenreDto);
    Task DeleteGenreAsync(Guid id);
  }
}
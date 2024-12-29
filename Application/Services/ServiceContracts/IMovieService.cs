using MvcCleanArch.Application.DTOs.MovieDtos;

namespace MvcCleanArch.Application.Services.ServiceContracts
{
  public interface IMovieService
  {
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    Task<MovieDto?> GetMovieByIdAsync(Guid id);
    Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto);
    Task<MovieDto> UpdateMovieAsync(Guid movieId, UpdateMovieDto updateMovieDto);
    Task DeleteMovieAsync(Guid id);
    Task ToggleFavouriteAsync(string userId, Guid movieId);
  }
}
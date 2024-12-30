using MvcCleanArch.Application.DTOs.MovieDtos;
using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Application.Services.ServiceContracts
{
  public interface IMovieService
  {
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<Movie?> GetMovieByIdAsync(Guid id);
    Task<Movie> CreateMovieAsync(CreateMovieDto createMovieDto);
    Task<Movie> UpdateMovieAsync(Guid movieId, UpdateMovieDto updateMovieDto);
    Task DeleteMovieAsync(Guid id);
    Task ToggleFavouriteAsync(string userId, Guid movieId);
  }
}
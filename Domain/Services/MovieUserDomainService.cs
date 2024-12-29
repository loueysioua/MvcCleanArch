using MvcCleanArch.Domain.Models;
using Microsoft.Extensions.Logging;
using MvcCleanArch.Domain.Services.ServiceContracts;
using MvcCleanArch.Domain.Interfaces;

namespace MvcCleanArch.Domain.Services
{
  public class MovieUserDomainService : IMovieUserDomainService
  {
    private readonly IMovieUserRepository _userMovieRepository;
    private readonly ILogger<MovieUserDomainService> _logger;

    public MovieUserDomainService(IMovieUserRepository userMovieRepository, ILogger<MovieUserDomainService> logger)
    {
      _userMovieRepository = userMovieRepository;
      _logger = logger;
    }

    public async Task<MovieUser?> GetByUserIdAndMovieIdAsync(string userId, Guid movieId)
    {
      try
      {
        return await _userMovieRepository.GetByIdAsync(movieId, userId,);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while getting the MovieUser with UserId {userId} and MovieId {movieId}.");
        throw;
      }
    }

    public async Task ToggleFavouriteAsync(MovieUser movieUser)
    {
      if (movieUser == null)
      {
        throw new ArgumentNullException(nameof(movieUser));
      }

      try
      {
        movieUser.IsFavourite = !movieUser.IsFavourite;
        await _userMovieRepository.UpdateAsync(movieUser);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while toggling favourite for MovieUser with UserId {movieUser.UserId} and MovieId {movieUser.MovieId}.");
        throw;
      }
    }
  }
}
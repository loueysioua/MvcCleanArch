using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Domain.Services.ServiceContracts
{
  public interface IMovieUserDomainService
  {
    Task<MovieUser?> GetByUserIdAndMovieIdAsync(string userId, Guid movieId);
    Task ToggleFavouriteAsync(MovieUser movieUser);
  }
}
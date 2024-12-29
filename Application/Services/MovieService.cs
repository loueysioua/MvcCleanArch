using AutoMapper;
using MvcCleanArch.Application.DTOs.MovieDtos;
using MvcCleanArch.Application.Services.ServiceContracts;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Domain.Services.ServiceContracts;
using Microsoft.Extensions.Logging;
using MvcCleanArch.Domain.Interfaces;


namespace MvcCleanArch.Application.Services
{
  public class MovieService : IMovieService
  {
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<MovieService> _logger;
    private readonly IMovieUserDomainService _movieUserService;

    public MovieService(IMovieRepository movieRepository, IMapper mapper, ILogger<MovieService> logger, IMovieUserDomainService movieUserService)
    {
      _movieRepository = movieRepository;
      _mapper = mapper;
      _logger = logger;
      _movieUserService = movieUserService;
    }

    public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
    {
      try
      {
        var movies = await _movieRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MovieDto>>(movies);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "An error occurred while getting all movies.");
        throw;
      }
    }

    public async Task<MovieDto?> GetMovieByIdAsync(Guid id)
    {
      try
      {
        var movie = await _movieRepository.GetByIdAsync(id);
        return movie == null ? null : _mapper.Map<MovieDto>(movie);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while getting the movie with ID {id}.");
        throw;
      }
    }

    public async Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto)
    {
      try
      {
        var movie = _mapper.Map<Movie>(createMovieDto);
        await _movieRepository.AddAsync(movie);
        return _mapper.Map<MovieDto>(movie);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "An error occurred while creating a new movie.");
        throw;
      }
    }

    public async Task<MovieDto> UpdateMovieAsync(Guid movieId, UpdateMovieDto updateMovieDto)
    {
      try
      {
        var movie = await _movieRepository.GetByIdAsync(movieId);
        if (movie == null)
        {
          _logger.LogWarning($"Movie with ID {movieId} not found.");
          throw new KeyNotFoundException("Movie not found");
        }

        _mapper.Map(updateMovieDto, movie);
        await _movieRepository.UpdateAsync(movie);
        return _mapper.Map<MovieDto>(movie);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while updating the movie with ID {movieId}.");
        throw;
      }
    }

    public async Task DeleteMovieAsync(Guid id)
    {
      try
      {
        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null)
        {
          _logger.LogWarning($"Movie with ID {id} not found.");
          throw new KeyNotFoundException("Movie not found");
        }

        await _movieRepository.DeleteAsync(movie.Id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while deleting the movie with ID {id}.");
        throw;
      }
    }

    public async Task ToggleFavouriteAsync(string userId, Guid movieId)
    {
      try
      {
        var movieUser = await _movieUserService.GetByUserIdAndMovieIdAsync(userId, movieId);
        if (movieUser != null)
          await _movieUserService.ToggleFavouriteAsync(movieUser);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while toggling favorite for movie with ID {movieId} and user ID {userId}.");
        throw;
      }
    }
  }
}
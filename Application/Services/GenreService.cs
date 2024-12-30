using AutoMapper;
using MvcCleanArch.Application.DTOs.GenreDtos;
using MvcCleanArch.Application.Services.ServiceContracts;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace MvcCleanArch.Application.Services
{
  public class GenreService : IGenreService
  {
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GenreService> _logger;

    public GenreService(IGenreRepository genreRepository, IMapper mapper, ILogger<GenreService> logger)
    {
      _genreRepository = genreRepository;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
      try
      {
        var genres = await _genreRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Genre>>(genres);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "An error occurred while getting all genres.");
        throw;
      }
    }

    public async Task<Genre?> GetGenreByIdAsync(Guid id)
    {
      try
      {
        var genre = await _genreRepository.GetByIdAsync(id);
        return genre == null ? null : _mapper.Map<Genre>(genre);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while getting the genre with ID {id}.");
        throw;
      }
    }

    public async Task<Genre> CreateGenreAsync(CreateGenreDto createGenreDto)
    {
      try
      {
        var genre = _mapper.Map<Genre>(createGenreDto);
        genre.Id = Guid.NewGuid();
        await _genreRepository.AddAsync(genre);
        return _mapper.Map<Genre>(genre);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "An error occurred while creating a new genre.");
        throw;
      }
    }

    public async Task<Genre> UpdateGenreAsync(Guid genreId, UpdateGenreDto updateGenreDto)
    {
      try
      {
        var genre = await _genreRepository.GetByIdAsync(genreId);
        if (genre == null)
        {
          _logger.LogWarning($"Genre with ID {genreId} not found.");
          throw new KeyNotFoundException("Genre not found");
        }

        _mapper.Map(updateGenreDto, genre);
        await _genreRepository.UpdateAsync(genre);
        return genre;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while updating the genre with ID {genreId}.");
        throw;
      }
    }

    public async Task DeleteGenreAsync(Guid id)
    {
      try
      {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre == null)
        {
          _logger.LogWarning($"Genre with ID {id} not found.");
          throw new KeyNotFoundException("Genre not found");
        }

        await _genreRepository.DeleteAsync(genre.Id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while deleting the genre with ID {id}.");
        throw;
      }
    }
  }
}
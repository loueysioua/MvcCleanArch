using AutoMapper;
using MvcCleanArch.Application.DTOs.UserDtos;
using MvcCleanArch.Application.Services.ServiceContracts;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace MvcCleanArch.Application.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
    {
      _userRepository = userRepository;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      try
      {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "An error occurred while getting all users.");
        throw;
      }
    }

    public async Task<UserDto?> GetUserByIdAsync(string id)
    {
      try
      {
        var user = await _userRepository.GetByIdAsync(id);
        return user == null ? null : _mapper.Map<UserDto>(user);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while getting the user with ID {id}.");
        throw;
      }
    }

    public async Task CreateUserAsync(CreateUserDto createUserDto)
    {
      try
      {
        var user = _mapper.Map<AppUser>(createUserDto);
        user.Id = Guid.NewGuid().ToString();
        await _userRepository.AddAsync(user);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "An error occurred while creating a new user.");
        throw;
      }
    }

    public async Task UpdateUserAsync(string id, UpdateUserDto updateUserDto)
    {
      try
      {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
          _logger.LogWarning($"User with ID {id} not found.");
          throw new KeyNotFoundException("User not found");
        }

        _mapper.Map(updateUserDto, user);
        await _userRepository.UpdateAsync(user);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while updating the user with ID {id}.");
        throw;
      }
    }

    public async Task DeleteUserAsync(string id)
    {
      try
      {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
          _logger.LogWarning($"User with ID {id} not found.");
          throw new KeyNotFoundException("User not found");
        }

        await _userRepository.DeleteAsync(user.Id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An error occurred while deleting the user with ID {id}.");
        throw;
      }
    }
  }
}
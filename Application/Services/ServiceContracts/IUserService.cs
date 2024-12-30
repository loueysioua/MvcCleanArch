using MvcCleanArch.Application.DTOs.UserDtos;
using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Application.Services.ServiceContracts
{
  public interface IUserService
  {
    Task<IEnumerable<AppUser>> GetAllUsersAsync();
    Task<AppUser?> GetUserByIdAsync(string id);
    Task<AppUser> CreateUserAsync(CreateUserDto createUserDto);
    Task<AppUser> UpdateUserAsync(string id, UpdateUserDto updateUserDto);
    Task DeleteUserAsync(string id);
  }
}
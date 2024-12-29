using MvcCleanArch.Application.DTOs.UserDtos;

namespace MvcCleanArch.Application.Services.ServiceContracts
{
  public interface IUserService
  {
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserByIdAsync(string id);
    Task CreateUserAsync(CreateUserDto createUserDto);
    Task UpdateUserAsync(string id, UpdateUserDto updateUserDto);
    Task DeleteUserAsync(string id);
  }
}
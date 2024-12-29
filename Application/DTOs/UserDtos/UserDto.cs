using MvcCleanArch.Application.DTOs.MovieDtos;

namespace MvcCleanArch.Application.DTOs.UserDtos
{
  public class UserDto
  {
    public required string Id { get; set; }
    public string? UserName { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public bool ConfirmPassword { get; set; } = false;
    public bool ConfirmEmail { get; set; } = false;

  }
}
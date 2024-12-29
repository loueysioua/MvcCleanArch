namespace MvcCleanArch.Application.DTOs.UserDtos
{
  public class CreateUserDto
  {
    public string? UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
  }
}
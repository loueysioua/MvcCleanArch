namespace MvcCleanArch.Application.DTOs.UserDtos
{
  public class UpdateUserDto
  {
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public bool PhoneNumberConfirmed { get; set; } = false;
    public bool EmailConfirmed { get; set; } = false;

  }
}
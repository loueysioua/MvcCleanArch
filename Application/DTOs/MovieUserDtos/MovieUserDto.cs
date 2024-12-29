namespace MvcCleanArch.Application.DTOs.MovieDtos
{
  public class MovieUserDto
  {
    public Guid MovieId { get; set; }
    public required string UserId { get; set; }
    public bool IsFavourite { get; set; } = false;
  }
}
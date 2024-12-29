namespace MvcCleanArch.Application.DTOs.MovieDtos
{
  public class MovieDto
  {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid GenreId { get; set; }

  }
}
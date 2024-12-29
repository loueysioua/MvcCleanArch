namespace MvcCleanArch.Application.DTOs.MovieDtos
{
  public class CreateMovieDto
  {
    public required string Name { get; set; }
    public Guid GenreId { get; set; }
  }
}
namespace MvcCleanArch.Application.DTOs.MovieDtos
{
  public class UpdateMovieDto
  {
    public string? Name { get; set; }
    public Guid? GenreId { get; set; }
    public bool IsFavorite { get; set; }

  }
}
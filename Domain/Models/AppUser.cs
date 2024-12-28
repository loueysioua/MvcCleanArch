using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcCleanArch.Domain.Models
{
  public class AppUser : IdentityUser
  {
    [Required]
    [Display(Name = "First Name")]
    [StringLength(15, ErrorMessage = "First Name must be at most 15 characters long")]
    [MinLength(3, ErrorMessage = "First Name must be at least 3 characters long")]
    public required string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(25, ErrorMessage = "Last Name must be at most 25 characters long")]
    [MinLength(3, ErrorMessage = "Last Name must be at least 3 characters long")]
    public required string LastName { get; set; }

    public virtual ICollection<MovieUser> Movies { get; set; } = new List<MovieUser>();

    public virtual IEnumerable<Movie> FavouriteMovies => Movies
        .Where(um => um.IsFavourite)
        .Select(um => um.Movie);
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCleanArch.Models;

public class Genre
{
  [Key]
  public Guid Id { get; set; }

  [Required]
  [Display(Name = "Genre Name")]
  [StringLength(50, ErrorMessage = "Genre Name must be at most 50 characters long")]
  [MinLength(3, ErrorMessage = "Genre Name must be at least 3 characters long")]
  public string? GenreName { get; set; }

  public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
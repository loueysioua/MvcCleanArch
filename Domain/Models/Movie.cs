using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCleanArch.Domain.Models
{
  public class Movie
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "Movie Name")]
    [StringLength(100, ErrorMessage = "Movie Name must be at most 100 characters long")]
    [MinLength(2, ErrorMessage = "Movie Name must be at least 2 characters long")]
    public required string Name { get; set; }

    [Required]
    [ForeignKey("Genre")]
    public Guid GenreId { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<MovieUser>? Users { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCleanArch.Models
{
  public class Movie
  {
    public Guid Id { get; set; }
    public string? Name { get; set; }

    [Required]
    public Guid GenreId { get; set; }
    public virtual Genre? Genre { get; set; }
    public virtual ICollection<MovieUser>? Users { get; set; }
  }
}
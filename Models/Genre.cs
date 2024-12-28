using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCleanArch.Models;

public class Genre
{
  public Guid Id { get; set; }
  public string? GenreName { get; set; }
  public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Domain.Models
{
  public class MovieUser
  {
    [Key]
    public Guid MovieId { get; set; }
    [Key]
    public required string UserId { get; set; }

    [DefaultValue(false)]
    public bool IsFavourite { get; set; }
    public virtual required Movie Movie { get; set; }
    public virtual required AppUser User { get; set; }
  }
}
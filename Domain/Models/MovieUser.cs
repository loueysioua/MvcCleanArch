using System;
using System.Collections.Generic;
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
    public string UserId { get; set; }
    public virtual Movie? Movie { get; set; }
    public virtual AppUser? User { get; set; }
  }
}
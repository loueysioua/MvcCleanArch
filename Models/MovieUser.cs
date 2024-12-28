using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MvcCleanArch.Models;

namespace MvcCleanArch.Models
{
  public class MovieUser
  {
    [Key]
    public Guid MovieId { get; set; }
    [Key]
    public Guid UserId { get; set; }
    public virtual Movie? Movie { get; set; }
    public virtual AppUser? User { get; set; }
  }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCleanArch.Models
{
  public class Todo
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Title must be at most 50 characters long")]
    public required string Title { get; set; }

    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Description { get; set; }

    [Required]
    public required string UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }
  }
}
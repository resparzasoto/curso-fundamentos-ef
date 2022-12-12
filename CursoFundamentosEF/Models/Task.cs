using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoFundamentosEF.Models;

public class Task
{
    [Key]
    public Guid TaskId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public string Description { get; set; }

    public Priority PriorityTask { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Category Category { get; set; }

    [NotMapped]
    public string Summary { get; set; }
}

public enum Priority
{
    Low = 1,
    Medium,
    High
}
using System.ComponentModel.DataAnnotations;

namespace CursoFundamentosEF.Models;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Task> Tasks { get; set; }
}
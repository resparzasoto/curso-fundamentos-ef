namespace CursoFundamentosEF.Models;

public class Task
{
    public Guid TaskId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority PriorityTask { get; set; }

    public DateTime CreatedAt { get; set; }

    // relationships
    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; }

    // not mapped
    public string Summary { get; set; }
}

public enum Priority
{
    Low = 1,
    Medium,
    High
}
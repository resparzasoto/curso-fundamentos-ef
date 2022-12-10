namespace CursoFundamentosEF.Models;

public class Task
{
    public Guid TaskId { get; set; }

    public Guid CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority PriorityTask { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Category Category { get; set; }
}

public enum Priority
{
    Low = 1,
    Medium,
    High
}
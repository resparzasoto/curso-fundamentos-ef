using CursoFundamentosEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoFundamentosEF;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Category>(category => {
            category.ToTable("Category");
            category.HasKey(t => t.CategoryId);

            category.Property(t => t.Name).IsRequired().HasMaxLength(150);
            category.Property(t => t.Description);

            category.Property(t => t.Tasks);
        });

        modelBuilder.Entity<Models.Task>(task => {
            task.ToTable("Task");
            task.HasKey(t => t.TaskId);

            task.Property(t => t.Title).IsRequired().HasMaxLength(200);
            task.Property(t => t.Description);
            task.Property(t => t.PriorityTask).HasConversion(
                v => v.ToString(),
                v => (Priority) Enum.Parse(typeof(Priority),
                v
            ));
            task.Property(t => t.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);
        });
    }
}
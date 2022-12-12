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
        });
    }
}
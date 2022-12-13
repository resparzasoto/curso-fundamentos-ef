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
        List<Models.Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() {
            CategoryId = Guid.Parse("d22d110c-1064-4a0a-a654-1f5a0f0856ea"),
            Name = "Financial",
            Description = "Category about financial activities",
            Weight = 10
        });
        categoriesInit.Add(new Category() {
            CategoryId = Guid.Parse("45f3c893-8e07-4e4c-9f34-fd63f9552636"),
            Name = "Learn",
            Description = "Category about learn activities",
            Weight = 8
        });

        modelBuilder.Entity<Models.Category>(category => {
            category.ToTable("Category");
            category.HasKey(t => t.CategoryId);

            category.Property(t => t.Name).IsRequired().HasMaxLength(150);
            category.Property(t => t.Description);
            category.Property(t => t.Weight);

            category.HasData(categoriesInit);
        });

        List<Models.Task> tasksInit = new List<Models.Task>();
        tasksInit.Add(new Models.Task() {
            TaskId = Guid.Parse("18c6b94f-5344-436b-b102-0301e98b1728"),
            CategoryId = Guid.Parse("d22d110c-1064-4a0a-a654-1f5a0f0856ea"),
            Title = "Check bills of gifts",
            PriorityTask = Priority.High,
            CreatedAt = DateTime.UtcNow
        });
        tasksInit.Add(new Models.Task() {
            TaskId = Guid.Parse("90a13ed7-c79f-4a67-a081-bbef420fcf0b"),
            CategoryId = Guid.Parse("45f3c893-8e07-4e4c-9f34-fd63f9552636"),
            Title = "Learn about compound interest",
            PriorityTask = Priority.Low,
            CreatedAt = DateTime.UtcNow
        });

        modelBuilder.Entity<Models.Task>(task => {
            task.ToTable("Task");
            task.HasKey(t => t.TaskId);

            task.Property(t => t.Title).IsRequired().HasMaxLength(200);
            task.Property(t => t.Description).IsRequired(false);
            task.Property(t => t.PriorityTask).HasConversion(typeof(int));
            task.Property(t => t.CreatedAt).HasDefaultValueSql("now()");

            task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);

            task.Ignore(t => t.Summary);

            task.HasData(tasksInit);
        });
    }
}
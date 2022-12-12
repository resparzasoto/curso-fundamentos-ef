using CursoFundamentosEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoFundamentosEF;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) {}
}
using Microsoft.EntityFrameworkCore;
using CursoFundamentosEF;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsql<TasksContext>(builder.Configuration.GetConnectionString("TasksDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", ([FromServices] TasksContext dbContext) => {
    if (!dbContext.Database.EnsureCreated())
        return Results.Ok("Database is not ready");

    if (dbContext.Database.IsInMemory())
        return Results.Ok("Database is in memory");

    return Results.Ok("Database is not in memory");
});

app.MapGet("/api/categories", ([FromServices] TasksContext dbContext) => {
    return Results.Ok(dbContext.Categories.ToList());
});

app.MapGet("/api/tasks", ([FromServices] TasksContext dbContext) => {
    return Results.Ok(dbContext.Tasks.Include(t => t.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] CursoFundamentosEF.Models.Task task) =>
{
    await dbContext.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();

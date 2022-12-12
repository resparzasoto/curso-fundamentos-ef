using Microsoft.EntityFrameworkCore;
using CursoFundamentosEF;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", ([FromServices] TasksContext dbContext) => {
    if (!dbContext.Database.EnsureCreated())
        return Results.Ok("Database is not ready");

    return Results.Ok($"Database in memory: { dbContext.Database.IsInMemory() }");
});

app.Run();

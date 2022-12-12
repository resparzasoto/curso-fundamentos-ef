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

app.Run();

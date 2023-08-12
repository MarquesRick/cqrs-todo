using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<SQLiteContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/v1/todos/getAll", ([FromServices]ITodoRepository repository)=>
{
    return repository.GetAll("Henrique");
});

app.MapPost("v1/todos/create", ([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)=>
{
    //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
    command.User = "Henrique";
    return (GenericCommandResult)handler.Handle(command);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

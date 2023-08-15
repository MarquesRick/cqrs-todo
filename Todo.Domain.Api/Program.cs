using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Api.Middleware;
using Todo.Domain.Behaviors;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// To get current folder from Todo.Domain.Infra and set in appsettings to indicate where app.db is.
var stringConnection = builder.Configuration
    .GetConnectionString("DefaultConnection")
    .Replace("{PATH}", $"{Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../"))}Todo.Domain.Infra");

builder.Services.AddDbContext<SQLiteContext>(option => option
    .UseSqlite(stringConnection));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddTransient<TodoHandler, TodoHandler>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var todoDomainAssembly = typeof(TodoDomain.AssemblyReference).Assembly;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(todoDomainAssembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
//builder.Services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
//builder.Services.AddValidatorsFromAssembly(applicationAssembly);
builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(todoDomainAssembly);
    conf.AutomaticValidationEnabled = false;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//# region Gets
//app.MapGet("/v1/todos/all", ([FromServices]ITodoRepository repository)=>
//{
//    return repository.GetAll("Henrique");
//});
//app.MapGet("/v1/todos/allDone", ([FromServices] ITodoRepository repository) =>
//{
//    return repository.GetAllDone("Henrique");
//});
//app.MapGet("/v1/todos/allUndone", ([FromServices] ITodoRepository repository) =>
//{
//    return repository.GetAllUndone("Henrique");
//});
//app.MapGet("/v1/todos/done/today", ([FromServices] ITodoRepository repository) =>
//{
//    return repository.GetByPeriod("Henrique", DateTime.Now.Date, true);
//});
//app.MapGet("/v1/todos/undone/today", ([FromServices] ITodoRepository repository) =>
//{
//    return repository.GetByPeriod("Henrique", DateTime.Now.Date, false);
//});
//app.MapGet("/v1/todos/done/tomorrow", ([FromServices] ITodoRepository repository) =>
//{
//    return repository.GetByPeriod("Henrique", DateTime.Now.Date.AddDays(1), true);
//});
//app.MapGet("/v1/todos/undone/tomorrow", ([FromServices] ITodoRepository repository) =>
//{
//    return repository.GetByPeriod("Henrique", DateTime.Now.Date.AddDays(1), false);
//});
//#endregion

//# region Commands
//app.MapPost("v1/todos/create", ([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)=>
//{
//    //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
//    command.User = "Henrique";
//    return (GenericCommandResult)handler.Handle(command);
//});
//app.MapPut("v1/todos/update", ([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler) =>
//{
//    //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
//    command.User = "Henrique";
//    return (GenericCommandResult)handler.Handle(command);
//});
//app.MapPut("v1/todos/mark-as-done", ([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler) =>
//{
//    //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
//    command.User = "Henrique";
//    return (GenericCommandResult)handler.Handle(command);
//});
//app.MapPut("v1/todos/mark-as-undone", ([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler) =>
//{
//    //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
//    command.User = "Henrique";
//    return (GenericCommandResult)handler.Handle(command);
//});
//#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

//setup cors - allowed
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

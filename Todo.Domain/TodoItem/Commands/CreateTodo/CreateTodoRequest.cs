using System;
namespace Todo.Domain.TodoItem.Commands.CreateTodo
{
    public sealed record CreateTodoRequest(string Title, string User, DateTime Date);
}


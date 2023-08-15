using System;
namespace Todo.Domain.TodoItem.Commands.UpdateTodo
{
    public sealed record UpdateTodoRequest(Guid Id, string Title);
}


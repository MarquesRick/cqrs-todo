using System;
namespace Todo.Domain.Contracts.TodoItem
{
    public sealed record TodoItemResponse(bool success, string message, object data);
}


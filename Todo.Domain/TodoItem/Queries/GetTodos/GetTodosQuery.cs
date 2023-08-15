using System;
using Todo.Domain.Abstractions.Messaging;
using Todo.Domain.Contracts.TodoItem;

namespace Todo.Domain.TodoItem.Queries.GetTodos
{
    public sealed record GetTodosQuery() : IQuery<List<TodoItemResponse>>;
}


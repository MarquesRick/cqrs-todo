using System;
using Todo.Domain.Abstractions.Messaging;
using Todo.Domain.Contracts.TodoItem;

namespace Todo.Domain.TodoItem.Commands.CreateTodo
{

   public sealed record CreateTodoCommand(string Title, string User, DateTime Date) : ICommand<TodoItemResponse>;
}


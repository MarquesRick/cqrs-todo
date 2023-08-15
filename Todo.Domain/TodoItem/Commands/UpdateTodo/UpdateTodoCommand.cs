using System;
using MediatR;
using Todo.Domain.Abstractions.Messaging;

namespace Todo.Domain.TodoItem.Commands.UpdateTodo
{
    //Unit == For return a void -> MediatR
    public sealed record UpdateTodoCommand(Guid Id, string Title, string User) : ICommand<Unit>;
}


using System;
using Mapster;
using Todo.Domain.Abstractions.Messaging;
using Todo.Domain.Commands;
using Todo.Domain.Contracts.TodoItem;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.TodoItem.Commands.CreateTodo
{
    internal sealed class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, TodoItemResponse>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoItemResponse> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
        {
            var todo = new TodoItemEntity(command.Title, command.User, command.Date);

            _todoRepository.Create(todo);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return todo.Adapt<TodoItemResponse>();
        }
    }
}


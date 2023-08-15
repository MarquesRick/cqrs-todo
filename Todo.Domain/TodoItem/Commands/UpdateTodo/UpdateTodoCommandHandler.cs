using System;
using MediatR;
using Todo.Domain.Abstractions.Messaging;
using Todo.Domain.Exceptions.Todo;
using Todo.Domain.Repositories;

namespace Todo.Domain.TodoItem.Commands.UpdateTodo
{
    internal sealed class UpdateTodoCommandHandler : ICommandHandler<UpdateTodoCommand, Unit>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(request.Id, cancellationToken);

            if (todo is null)
                throw new TodoNotFoundException(request.Id);

            todo.UpdateTitle(request.Title);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //if return a void
            return Unit.Value;
        }
    }
}


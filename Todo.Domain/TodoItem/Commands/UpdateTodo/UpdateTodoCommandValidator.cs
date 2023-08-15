using System;
using FluentValidation;

namespace Todo.Domain.TodoItem.Commands.UpdateTodo
{

    public sealed class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Title).NotEmpty().MinimumLength(3);
        }
    }
}


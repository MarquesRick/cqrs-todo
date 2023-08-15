using System;
using FluentValidation;

namespace Todo.Domain.TodoItem.Commands.CreateTodo
{
    public sealed class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            //TODO: IMPLEMENT CUSTOM MESSAGE
            //"Please, Describe better this task!"
            RuleFor(x => x.Title).NotEmpty().MinimumLength(3);

            //"Invalid User"
            RuleFor(x => x.User).NotEmpty().MinimumLength(6);
        }
    }
}


using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
    Notifiable,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
    {
        // private readonly IRepository<Todo> _repository;
        public ICommandResult Handle(CreateTodoCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
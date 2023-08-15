//using Flunt.Notifications;
//using Todo.Domain.Commands;
//using Todo.Domain.Commands.Contracts;
//using Todo.Domain.Entities;
//using Todo.Domain.Handlers.Contracts;
//using Todo.Domain.Repositories;

//namespace Todo.Domain.Handlers
//{
//    public class TodoHandler :
//    Notifiable,
//    IHandler<CreateTodoCommand>,
//    IHandler<UpdateTodoCommand>,
//    IHandler<MarkTodoAsDoneCommand>,
//    IHandler<MarkTodoAsUndoneCommand>
//    {
//        private readonly ITodoRepository _repository;

//        public TodoHandler(ITodoRepository repository)
//        {
//            _repository = repository;
//        }

//        public ICommandResult Handle(CreateTodoCommand command)
//        {
//            // Fail Fast Validation
//            command.Validate();
//            if (command.Invalid)
//                return new GenericCommandResult(false, "Ops, It seems that your task is wrong!", command.Notifications);
//            // Generate TodoItem
//            var todo = new TodoItemEntity(command.Title, command.User, command.Date);
//            // Save on db
//            _repository.Create(todo);

//            // Returns the result
//            return new GenericCommandResult(true, "Task saved!", todo);
//        }

//        public ICommandResult Handle(UpdateTodoCommand command)
//        {
//            // Fail Fast Validation
//            command.Validate();
//            if (command.Invalid)
//                return new GenericCommandResult(false, "Ops, It seems that your task is wrong!", command.Notifications);

//            var todo = _repository.GetById(command.Id, command.User);
//            todo.UpdateTitle(command.Title);
//            _repository.Update(todo);

//            return new GenericCommandResult(true, "Task saved", todo);
//        }

//        public ICommandResult Handle(MarkTodoAsDoneCommand command)
//        {
//            // Fail Fast Validation
//            command.Validate();
//            if (command.Invalid)
//                return new GenericCommandResult(false, "Ops, It seems that your task is wrong!", command.Notifications);
//            var todo = _repository.GetById(command.Id, command.User);
//            todo.MarkAsDone();
//            _repository.Update(todo);

//            // Retorna o resultado
//            return new GenericCommandResult(true, "Task saved", todo);
//        }

//        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
//        {
//            // Fail Fast Validation
//            command.Validate();
//            if (command.Invalid)
//                return new GenericCommandResult(false, "Ops, It seems that your task is wrong!", command.Notifications);
//            var todo = _repository.GetById(command.Id, command.User);
//            todo.MarkAsUndone();
//            _repository.Update(todo);

//            return new GenericCommandResult(true, "Task saved", todo);
//        }
//    }
//}
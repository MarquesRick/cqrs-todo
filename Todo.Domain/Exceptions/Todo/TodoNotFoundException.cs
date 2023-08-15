using System;
namespace Todo.Domain.Exceptions.Todo
{
    public sealed class TodoNotFoundException : NotFoundException
    {
        public TodoNotFoundException(Guid id)
            : base($"The todo with the identifier {id} was not found.") { }
    }
}


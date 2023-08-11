using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItemEntity todo);
        void Update(TodoItemEntity todo);
        TodoItemEntity GetById(Guid id, string user);
        IEnumerable<TodoItemEntity> GetAll(string user);
        IEnumerable<TodoItemEntity> GetAllDone(string user);
        IEnumerable<TodoItemEntity> GetAllUndone(string user);
        IEnumerable<TodoItemEntity> GetByPeriod(string user, DateTime date, bool done);
    }
}
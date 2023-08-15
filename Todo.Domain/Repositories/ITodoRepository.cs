using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItemEntity todo);
        void Update(TodoItemEntity todo);
        Task<TodoItemEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItemEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItemEntity>> GetAllDone(string username, CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItemEntity>> GetAllUndone(string username, CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItemEntity>> GetByPeriod(string user, DateTime date, bool done, CancellationToken cancellationToken = default);
    }
}
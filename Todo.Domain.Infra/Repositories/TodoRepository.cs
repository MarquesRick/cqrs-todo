using System;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly SQLiteContext _context;

        public TodoRepository(SQLiteContext context)
        {
            _context = context;
        }

        public void Create(TodoItemEntity todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItemEntity> GetAll(string user)
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);

        public Task<List<TodoItemEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.Todos.AsNoTracking().ToListAsync(cancellationToken);
        }

        public IEnumerable<TodoItemEntity> GetAllDone(string user)
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);

        public Task<IEnumerable<TodoItemEntity>> GetAllDone(string username, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItemEntity> GetAllUndone(string user)
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);

        public Task<IEnumerable<TodoItemEntity>> GetAllUndone(string username, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TodoItemEntity GetById(Guid id, string user)
            => _context.Todos
                .FirstOrDefault(x => x.Id == id && x.User == user);

        public Task<TodoItemEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _context.Todos
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public IEnumerable<TodoItemEntity> GetByPeriod(string user, DateTime date, bool done)
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);

        public Task<IEnumerable<TodoItemEntity>> GetByPeriod(string user, DateTime date, bool done, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItemEntity todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
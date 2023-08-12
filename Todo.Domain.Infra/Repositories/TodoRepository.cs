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

        public IEnumerable<TodoItemEntity> GetAllDone(string user)
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);

        public IEnumerable<TodoItemEntity> GetAllUndone(string user)
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);

        public TodoItemEntity GetById(Guid id, string user)
            => _context.Todos
                .FirstOrDefault(x => x.Id == id && x.User == user);

        public IEnumerable<TodoItemEntity> GetByPeriod(string user, DateTime date, bool done)
            => _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);


        public void Update(TodoItemEntity todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
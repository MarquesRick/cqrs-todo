using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepositories : ITodoRepository
    {
        public void Create(TodoItemEntity todo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItemEntity> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItemEntity> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItemEntity> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public TodoItemEntity GetById(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItemEntity> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItemEntity todo)
        {
            throw new NotImplementedException();
        }
    }
}
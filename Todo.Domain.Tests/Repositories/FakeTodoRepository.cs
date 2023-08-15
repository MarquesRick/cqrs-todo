//using System;
//using Todo.Domain.Entities;
//using Todo.Domain.Repositories;

//namespace Todo.Domain.Tests.Repositories
//{
//    public class FakeTodoRepository : ITodoRepository
//    {
//        public void Create(TodoItemEntity todo)
//        {
            
//        }

//        public IEnumerable<TodoItemEntity> GetAll(string user)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<TodoItemEntity> GetAllDone(string user)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<TodoItemEntity> GetAllUndone(string user)
//        {
//            throw new NotImplementedException();
//        }

//        public TodoItemEntity GetById(Guid id, string user)
//        {
//            return new TodoItemEntity("Titulo Aqui", "Henrique", DateTime.Now);
//        }

//        public IEnumerable<TodoItemEntity> GetByPeriod(string user, DateTime date, bool done)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(TodoItemEntity todo)
//        {
            
//        }
//    }
//}


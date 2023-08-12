using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItemEntity, bool>> GetAll(string user)
            => x => x.User == user;

        public static Expression<Func<TodoItemEntity, bool>> GetAllDone(string user)
            => x => x.User == user && x.Done == true;


        public static Expression<Func<TodoItemEntity, bool>> GetAllUndone(string user)
            => x => x.User == user && x.Done == false;


        public static Expression<Func<TodoItemEntity, bool>> GetByPeriod(string user, DateTime date, bool done)
            => x =>
                x.User == user &&
                x.Done == done &&
                x.Date.Date == date.Date;

    }
}
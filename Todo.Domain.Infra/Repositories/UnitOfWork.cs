using System;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly SQLiteContext _dbContext;

        public UnitOfWork(SQLiteContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);
    }
}


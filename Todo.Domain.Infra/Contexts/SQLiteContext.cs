using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Mapping;

namespace Todo.Domain.Infra.Contexts
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options) { }

        public DbSet<TodoItemEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemEntity>(new TodoMap().Configure);
        }
        //For Dapper

        // public IDbConnection CreateConnection()
        // {
        //     return new SqliteConnection("Data Source=LocalDatabase.db");
        // }

        // public async Task Init()
        // {
        //     // create database tables if they don't exist
        //     using var connection = CreateConnection();
        //     await _initTodo();

        //     async Task _initTodo()
        //     {
        //         var sql = $@"
        //             CREATE TABLE IF NOT EXISTS 
        //             Todo (
        //                 Id TEXT NOT NULL PRIMARY KEY,
        //                 Title TEXT,
        //                 User TEXT,
        //                 Done BIT,
        //                 Date DATETIME
        //             );
        //         ";
        //         await connection.ExecuteAsync(sql);
        //     }
        // }
    }
}
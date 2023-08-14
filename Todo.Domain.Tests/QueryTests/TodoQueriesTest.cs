using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItemEntity> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItemEntity>();
            _items.Add(new TodoItemEntity("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItemEntity("Tarefa 2", "usuarioA", DateTime.Now));
            _items.Add(new TodoItemEntity("Tarefa 3", "Henrique", DateTime.Now));
            _items.Add(new TodoItemEntity("Tarefa 4", "usuarioA", DateTime.Now));
            _items.Add(new TodoItemEntity("Tarefa 5", "Henrique", DateTime.Now));
        }

        [TestMethod]
        public void Must_Returns_Only_User_Passed()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Henrique"));
            Assert.AreEqual(2, result.Count());
        }
    }
}


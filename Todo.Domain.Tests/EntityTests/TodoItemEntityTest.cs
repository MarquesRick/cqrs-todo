using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemEntityTest
    {
        private readonly TodoItemEntity _validTodo = new TodoItemEntity("Title here", "Henrique", DateTime.Now);

        [TestMethod]
        public void New_Todo_Is_Not_Done()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}


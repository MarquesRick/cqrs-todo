//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Todo.Domain.Commands;
//using Todo.Domain.Handlers;
//using Todo.Domain.Tests.Repositories;

//namespace Todo.Domain.Tests.HandlerTests
//{
//    [TestClass]
//    public class CreateTodoHandlerTest
//    {
//        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
//        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Title Here", "Henrique", DateTime.Now);
//        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
//        private GenericCommandResult _result = new GenericCommandResult();

//        public CreateTodoHandlerTest() { }

//        [TestMethod]
//        public void Must_Fail_Execution_When_Passing_Incorrect_Data()
//        {
//            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
//            Assert.AreEqual(_result.Success, false);
//        }

//        [TestMethod]
//        public void Must_Success_Execution_When_Passing_Correct_Data()
//        {
//            _result = (GenericCommandResult)_handler.Handle(_validCommand);
//            Assert.AreEqual(_result.Success, true);
//        }
//    }
//}
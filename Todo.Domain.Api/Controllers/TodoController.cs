using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Contracts.TodoItem;
using Todo.Domain.TodoItem.Commands.UpdateTodo;
using Todo.Domain.TodoItem.Queries.GetTodos;

namespace Todo.Domain.Api.Controllers
{
    /// <summary>
    /// The users controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class TodoController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController"/> class.
        /// </summary>
        /// <param name="sender"></param>
        public TodoController(ISender sender) => _sender = sender;

        /// <summary>
        /// Gets all todos.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The collection of todos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<TodoItemResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetTodosQuery();

            var todos = await _sender.Send(query, cancellationToken);

            return Ok(todos);
        }

        /// <summary>
        /// Updates the todo with the specified identifier based on the specified request, if it exists.
        /// </summary>
        /// <param name="todoId">The todo identifier.</param>
        /// <param name="request">The update user request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] UpdateTodoRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<UpdateTodoCommand>() with
            {
                Id = id
            };
            await _sender.Send(command, cancellationToken);
            return NoContent();
        }
    }
}


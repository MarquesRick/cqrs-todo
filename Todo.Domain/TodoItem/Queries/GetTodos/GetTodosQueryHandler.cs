using System;
using Mapster;
using Todo.Domain.Abstractions.Messaging;
using Todo.Domain.Contracts.TodoItem;
using Todo.Domain.Repositories;

namespace Todo.Domain.TodoItem.Queries.GetTodos
{
    internal sealed class GetTodosQueryHandler : IQueryHandler<GetTodosQuery, List<TodoItemResponse>>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodosQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoItemResponse>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var users = await _todoRepository.GetAllAsync(cancellationToken);
            var l = new List<TodoItemResponse>();
            users.ForEach(e =>
            {
                l.Add(new TodoItemResponse(true, "Succes", e));
            });

            return l;
            //return users.Adapt<List<TodoItemResponse>>();
        }
    }
}


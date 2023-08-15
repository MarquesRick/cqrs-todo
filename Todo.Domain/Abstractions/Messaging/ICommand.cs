using System;
using MediatR;

namespace Todo.Domain.Abstractions.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}


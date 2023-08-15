using System;
using MediatR;

namespace Todo.Domain.Abstractions.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}


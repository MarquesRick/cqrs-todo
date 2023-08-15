﻿using System;
namespace Todo.Domain.Exceptions
{
    public abstract class BadRequestException : ApplicationException
    {
        protected BadRequestException(string message)
            : base("Bad Request", message) { }
        
    }
}

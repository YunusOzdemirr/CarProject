using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Concrete;

namespace CarProject.Shared.Utilities.Exceptions
{
    public class NotFoundArgumentsException : Exception
    {
        public NotFoundArgumentsException(string message, IEnumerable<Error> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }
        public IEnumerable<Error> ValidationErrors { get; set; }
    }
}


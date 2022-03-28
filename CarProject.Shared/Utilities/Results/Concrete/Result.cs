using System;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Shared.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus, string message) : this(message)
        {
            ResultStatus = resultStatus;
        }
        public Result(string message)
        {
            Message = message;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
    }
}


using System;
using System.Net;
using CarProject.Shared.Entities.Concrete;
using CarProject.Shared.Results.ComplexTypes;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarProject.Api.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger _logger;

        public JsonExceptionFilter(IHostEnvironment env, ILogger<JsonExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            context.Result = new ObjectResult(new
            {
                Data = (object)null,
                Message = context.Exception.Message,
                Detail = context.Exception.StackTrace,
                ResultStatus = ResultStatus.Error,
                ValidationErrors = (Error)null,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.HttpContext.Request.GetDisplayUrl()
            })
            {
                StatusCode = 500
            };

        }
    }
}


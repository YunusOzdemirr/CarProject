using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace CarProject.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                switch (ex)
                {
                    case NotFoundArgumentException error1:
                        await NotFoundArgumentAsync(context, error1);
                        break;
                    case NotFoundArgumentsException error2:
                        await NotFoundArgumentsAsync(context, error2);
                        break;
                    case ValidationErrorsException error3:
                        await ValidationErrorsAsync(context, error3);
                        break;
                    default:
                        await GeneralException(context, ex);
                        break;
                }
            }
        }
        private async Task GeneralException(HttpContext context, Exception exception)
        {

            var problemDetails = new
            {
                ResultSteecvatus = ResultStatus.Error,
                Message = exception.Message,
                Detail = exception.StackTrace,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        private async Task NotFoundArgumentAsync(HttpContext context, NotFoundArgumentException exception)
        {

            var problemDetails = new
            {
                ResultStatus = ResultStatus.Warning,
                Message = exception.Message,
                Error = exception.ValidationError,
                StatusCode = HttpStatusCode.BadRequest,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var result = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        private async Task NotFoundArgumentsAsync(HttpContext context, NotFoundArgumentsException exception)
        {

            var problemDetails = new
            {
                ResultStatus = ResultStatus.Warning,
                Message = exception.Message,
                Error = exception.ValidationErrors,
                StatusCode = HttpStatusCode.BadRequest,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var result = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        private async Task ValidationErrorsAsync(HttpContext context, ValidationErrorsException exception)
        {

            var problemDetails = new
            {
                ResultStatus = ResultStatus.Warning,
                Message = exception.Message,
                ValidationError = exception.ValidationErrors,
                StatusCode = HttpStatusCode.BadRequest,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var result = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

    }
}


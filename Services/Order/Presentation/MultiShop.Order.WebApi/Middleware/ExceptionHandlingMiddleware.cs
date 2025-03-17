using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Exceptions.Validation;

namespace MultiShop.Order.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Exception Occured:{ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }

        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var exceptionDetails= GetExceptionDetails(ex);

            var problemDetails = new ProblemDetails
            {

                Status = exceptionDetails.StatusCode,
                Type = exceptionDetails.Title,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail,
                Instance = httpContext.TraceIdentifier
            };

            if (exceptionDetails.Errors != null)
            {
                problemDetails.Extensions.Add("errors", exceptionDetails.Errors);
            }

            httpContext.Response.StatusCode = exceptionDetails.StatusCode;
            
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }


        private ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                CustomValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "Validation error",
                    "One or more validation errors has occured",
                    "ValidationFailure",
                    validationException.Errors

                ),
                BusinessException businessException => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "One business error has occured",
                    "BusinessFailure",
                    businessException.Message,
                    null
                    ),
                NotFoundException notFoundException => new ExceptionDetails(
                    StatusCodes.Status404NotFound,
                    "Resource not found",
                    notFoundException.Message,
                    "NotFound",
                    null
                ),
                _ => new ExceptionDetails(
                     StatusCodes.Status500InternalServerError,
                     "An internal server error has occured",
                     exception.Message,
                     "Server Error",
                     null
                )
            };
        }
    }


    internal record ExceptionDetails(
        int StatusCode,
        string Message,
        string Detail,
        string Title,
        IEnumerable<object>? Errors
    );
}

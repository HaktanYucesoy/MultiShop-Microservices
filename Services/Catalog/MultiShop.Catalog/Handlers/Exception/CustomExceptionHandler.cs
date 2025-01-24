using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Exceptions.Category;
using System.Net;

namespace MultiShop.Catalog.Handlers.Exception
{
    public class CustomExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {

            int status = exception switch
            {
                NullReferenceException => StatusCodes.Status404NotFound,
                ArgumentException => StatusCodes.Status400BadRequest,
                ProductNotFoundException => StatusCodes.Status404NotFound,
                FailAddProductException=>StatusCodes.Status500InternalServerError,
                FailDeleteProductException=>StatusCodes.Status500InternalServerError,
                FailGetProductsException=>StatusCodes.Status500InternalServerError,
                FailUpdateProductException=>StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError

            };

            var problemDetails = new ProblemDetails()
            {
                Detail = exception.Message,
                Title = Enum.Parse<HttpStatusCode>(status.ToString()).ToString(),
                Status =status,
                Type = exception.GetType().Name,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails
            });

          

        }
    }
}

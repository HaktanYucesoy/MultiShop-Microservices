using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Exceptions.Category;
using MultiShop.Catalog.Exceptions.Product;
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
                CategoryNotFoundException => StatusCodes.Status404NotFound,
                FailAddCategoryException => StatusCodes.Status500InternalServerError,
                FailDeleteCategoryException => StatusCodes.Status500InternalServerError,
                FailGetCategoriesException => StatusCodes.Status500InternalServerError,
                FailUpdateCategoryException => StatusCodes.Status500InternalServerError,
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

            var problemDetailsContext = new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails
            };

            var response=await problemDetailsService.TryWriteAsync(problemDetailsContext);

            return response;

          

        }
    }
}

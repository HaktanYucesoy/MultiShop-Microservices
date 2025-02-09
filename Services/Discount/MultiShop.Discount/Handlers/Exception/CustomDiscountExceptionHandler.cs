using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using MultiShop.Discount.Exceptions;
using System.Diagnostics;
using System.Net;

namespace MultiShop.Discount.Handlers.Exception
{
    public class CustomDiscountExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
            int status = exception switch
            {
                NullReferenceException => StatusCodes.Status404NotFound,
                ArgumentException => StatusCodes.Status400BadRequest,
                NotFoundDiscountException=>StatusCodes.Status404NotFound,
                CreateDiscountException=> StatusCodes.Status500InternalServerError,
                GetAllDiscountsException=> StatusCodes.Status500InternalServerError,
                GetDiscountException=> StatusCodes.Status500InternalServerError,
                UpdateDiscountException=> StatusCodes.Status500InternalServerError,
                DeleteDiscountException=> StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError

            };


            httpContext.Response.StatusCode = status;
            httpContext.Response.ContentType = "application/json";
            Activity? activity = httpContext.Features.Get<IHttpActivityFeature>()?.Activity;
            var error = new
            {
                Status = status,
                Type = exception.GetType().Name,
                Title = Enum.Parse<HttpStatusCode>(status.ToString()).ToString(),
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                RequestId = $"{httpContext.TraceIdentifier}",
                TraceId = $"{activity!.Id}"
            };

            await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);

            return true;
        }
    }
}

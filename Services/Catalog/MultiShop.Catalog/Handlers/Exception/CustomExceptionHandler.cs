using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Exceptions.Category;
using MultiShop.Catalog.Exceptions.Product;
using MultiShop.Catalog.Exceptions.ProductDetail;
using MultiShop.Catalog.Exceptions.ProductImage;
using System.Diagnostics;
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
                ProductImageNotFoundException => StatusCodes.Status404NotFound,
                FailAddProductImageException => StatusCodes.Status500InternalServerError,
                FailDeleteProductImageException => StatusCodes.Status500InternalServerError,
                FailGetProductImagesException => StatusCodes.Status500InternalServerError,
                FailUpdateProductImageException => StatusCodes.Status500InternalServerError,
                ProductDetailNotFoundException => StatusCodes.Status404NotFound,
                FailAddProductDetailException => StatusCodes.Status500InternalServerError,
                FailDeleteProductDetailException => StatusCodes.Status500InternalServerError,
                FailGetProductDetailsException => StatusCodes.Status500InternalServerError,
                FailUpdateProductDetailException => StatusCodes.Status500InternalServerError,
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
                TraceId =$"{activity!.Id}"
            };

            await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);

            return true;



        }
    }
}

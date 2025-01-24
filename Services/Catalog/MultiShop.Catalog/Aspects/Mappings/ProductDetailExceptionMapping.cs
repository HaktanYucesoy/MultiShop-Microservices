using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Exceptions.ProductDetail;

namespace MultiShop.Catalog.Aspects.Mappings
{
    public class ProductDetailExceptionMapping
    {
        public static DomainExceptionMap<ProductDetailDomain> GetExceptionMap() =>
    new()
    {
        NotFoundException = typeof(ProductDetailNotFoundException),
        CreateFailedException = typeof(FailAddProductDetailException),
        DeleteFailedException = typeof(FailDeleteProductDetailException),
        UpdateFailedException = typeof(FailUpdateProductDetailException),
        GetFailedException = typeof(FailGetProductDetailsException)
    };
    }

    public class ProductDetailDomain
    {
    }
}

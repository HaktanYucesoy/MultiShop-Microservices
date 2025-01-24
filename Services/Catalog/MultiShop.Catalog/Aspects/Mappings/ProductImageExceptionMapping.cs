using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Exceptions.ProductImage;

namespace MultiShop.Catalog.Aspects.Mappings
{
    public class ProductImageExceptionMapping
    {
        public static DomainExceptionMap<ProductImageDomain> GetExceptionMap() =>
     new()
     {
         NotFoundException = typeof(ProductImageNotFoundException),
         CreateFailedException = typeof(FailAddProductImageException),
         DeleteFailedException = typeof(FailDeleteProductImageException),
         UpdateFailedException = typeof(FailUpdateProductImageException),
         GetFailedException = typeof(FailGetProductImagesException)
     };
    }

    public class ProductImageDomain
    {
    }
}

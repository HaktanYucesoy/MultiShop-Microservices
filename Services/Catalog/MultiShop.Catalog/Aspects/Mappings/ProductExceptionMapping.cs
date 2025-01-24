using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Exceptions.Product;

namespace MultiShop.Catalog.Aspects.Mappings
{
    public class ProductExceptionMapping
    {
        public static DomainExceptionMap<ProductDomain> GetExceptionMap() =>
     new()
     {
         NotFoundException = typeof(ProductNotFoundException),
         CreateFailedException = typeof(FailAddProductException),
         DeleteFailedException = typeof(FailDeleteProductException),
         UpdateFailedException = typeof(FailUpdateProductException),
         GetFailedException = typeof(FailGetProductsException)
     };
    }

    public class ProductDomain
    {
    }
}

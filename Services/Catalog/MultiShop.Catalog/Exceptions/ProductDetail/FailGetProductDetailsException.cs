

using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class FailGetProductDetailsException : Exception
    {
        public FailGetProductDetailsException() : base(ProductDetailMessages.ERROR_OCCURED_WHILE_GET_PRODUCT_DETAILS)
        {
        }
    }
}

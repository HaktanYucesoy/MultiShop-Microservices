using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailGetProductDetailsException : Exception
    {
        public FailGetProductDetailsException() : base(ProductMessages.ERROR_OCCURED_WHILE_GET_PRODUCTS)
        {
        }
    }
}

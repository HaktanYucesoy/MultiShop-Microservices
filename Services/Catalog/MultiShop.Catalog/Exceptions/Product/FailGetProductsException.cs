using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailGetProductsException : Exception
    {
        public FailGetProductsException() : base(ProductMessages.ERROR_OCCURED_WHILE_GET_PRODUCTS)
        {
        }
    }
}

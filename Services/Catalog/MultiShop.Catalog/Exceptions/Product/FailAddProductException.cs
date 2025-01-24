using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailAddProductDetailException:Exception
    {
        public FailAddProductDetailException():base(ProductMessages.ERROR_OCCURED_WHILE_ADDING_PRODUCT)
        {
            
        }
    }
}

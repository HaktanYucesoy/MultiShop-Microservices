using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailAddProductException:Exception
    {
        public FailAddProductException():base(ProductMessages.ERROR_OCCURED_WHILE_ADDING_PRODUCT)
        {
            
        }
    }
}

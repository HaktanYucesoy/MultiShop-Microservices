using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailUpdateProductDetailException:Exception
    {
        public FailUpdateProductDetailException():base(ProductMessages.ERROR_OCCURED_WHILE_UPDATING_PRODUCT)
        {
            
        }
    }
}

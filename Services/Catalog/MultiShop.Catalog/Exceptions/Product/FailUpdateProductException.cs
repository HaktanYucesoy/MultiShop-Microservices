using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailUpdateProductException:Exception
    {
        public FailUpdateProductException():base(ProductMessages.ERROR_OCCURED_WHILE_UPDATING_PRODUCT)
        {
            
        }
    }
}

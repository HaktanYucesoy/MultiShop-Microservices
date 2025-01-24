
using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailDeleteProductException:Exception
    {
        public FailDeleteProductException():base(ProductMessages.ERROR_OCCURED_WHILE_DELETING_PRODUCT)
        {
            
        }
    }
}

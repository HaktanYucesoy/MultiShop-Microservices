
using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class FailDeleteProductDetailException:Exception
    {
        public FailDeleteProductDetailException():base(ProductMessages.ERROR_OCCURED_WHILE_DELETING_PRODUCT)
        {
            
        }
    }
}
